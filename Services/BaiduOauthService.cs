using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Utils;

namespace Services
{
    public class BaiduOauthService
    {
        private static readonly string GetTokenUrl = "https://openapi.baidu.com/oauth/2.0/token";
        private static readonly string RedirectUrl = "http://www.cainqs.com:22001/Login/ThirdLoginIndex";
        private static readonly string AppKey = "YjvPbGLPaeIQN1bMbQE3EDpvVk2jPXQe";
        private static readonly string AppSecret = "GvGNf0LNDcH9MQMZan5dXjqaaUm9D7BU";
        private static readonly int BlockSize = 4 * 1024 * 1024;

        public static string GetOAuthLoginUrl()
        {
            var url = string.Format(@"http://openapi.baidu.com/oauth/2.0/authorize?response_type=code&client_id={0}&redirect_uri={1}&scope=basic,netdisk&display=popup&qrcode=1&force_login=1", AppKey, RedirectUrl);

            return url;
        }

        public async static Task<TokenReturnModel> GetToken(string code)
        {
            TokenReturnModel ret = new();

            Dictionary<string, string> dic = new();

            dic.Add("grant_type", "authorization_code");
            dic.Add("code", code);
            dic.Add("client_id", AppKey);
            dic.Add("client_secret", AppSecret);
            dic.Add("redirect_uri", RedirectUrl);

            var param = $"?grant_type=authorization_code&code={code}&client_id={AppKey}&client_secret={AppSecret}&redirect_uri={RedirectUrl}";

            var response = await HtmlHelper.Get(GetTokenUrl + param);

            ret = JsonConvert.DeserializeObject<TokenReturnModel>(response);

            return ret;
        }

        public static (long, int) FileSizeAndBlockCount(string file)
        {
            if (File.Exists(file))
            {
                var length = new FileInfo(file).Length;
                var count = (int)Math.Ceiling(length / (decimal)BlockSize);

                return (length, count);
            }
            else
            {
                return (0, 0);
            }
        }

        public static void SplitFile(string inputFile, int chunkSize, string path)
        {
            byte[] buffer = new byte[BlockSize];

            using (Stream input = File.OpenRead(inputFile))
            {
                int index = 0;
                while (input.Position < input.Length)
                {
                    using (Stream output = File.Create(path + "\\" + index))
                    {
                        int remaining = chunkSize, bytesRead;
                        while (remaining > 0 && (bytesRead = input.Read(buffer, 0,
                                Math.Min(remaining, BlockSize))) > 0)
                        {
                            output.Write(buffer, 0, bytesRead);
                            remaining -= bytesRead;
                        }
                    }
                    index++;
                }
            }
        }

        public static PrecreateModel PrecreateMD5(string filePath, string uploadPath)
        {
            PrecreateModel sendModel = new();
            FileInfo fileInfo = new(filePath);
            //列表值预设
            JArray Md5_list = new();

            int splitFileSize = 4 * 1024 * 1024;
            sendModel.file = filePath;
            sendModel.file_name = fileInfo.Name;
            sendModel.path = uploadPath;
            sendModel.size = fileInfo.Length;
            sendModel.block_list = "";
            sendModel.part_size = splitFileSize;
            sendModel.part_count = (int)Math.Ceiling((double)fileInfo.Length / splitFileSize);
            sendModel.part_read = 0;
            sendModel.content_md5 = MD5Helper.GetFileMD5(filePath);
            sendModel.slice_md5 = MD5Helper.File_md5_Slice(filePath);
            sendModel.local_ctime = DateTimeHelper.GetTimeStamp(fileInfo.CreationTime);
            sendModel.local_mtime = DateTimeHelper.GetTimeStamp(fileInfo.LastWriteTimeUtc);

            if (fileInfo.Length > splitFileSize)
            {
                using FileStream fs = new(filePath, FileMode.Open, FileAccess.Read);
                using (BinaryReader br = new(fs))
                {
                    bool isReadingComplete = false;
                    while (!isReadingComplete)
                    {
                        byte[] input = br.ReadBytes(splitFileSize);
                        Md5_list.Add(MD5Helper.GenerateMD5(input));
                        isReadingComplete = (input.Length != splitFileSize);
                    }
                    br.Close();
                }
                fs.Close();
            }
            else
            {
                Md5_list.Add(sendModel.content_md5.ToString());
            }

            sendModel.block_list = Md5_list.ToString();

            return sendModel;
        }

        public async static Task<PrecreateRetModel> Precreate(PrecreateModel entity, string token)
        {
            Dictionary<string, string> dic = new();

            dic.Add("path", entity.path);
            dic.Add("size", entity.size + "");
            dic.Add("isdir", "0");
            dic.Add("autoinit", "1");
            dic.Add("block_list", entity.block_list);

            var preCreateRes = await HtmlHelper.PostFromUrlencoded($"https://pan.baidu.com/rest/2.0/xpan/file?method=precreate&access_token={token}", dic);

            return JsonConvert.DeserializeObject<PrecreateRetModel>(preCreateRes);
        }

        public async static Task<PreuploadRetModel> PreUpload(PrecreateRetModel response, string path, string token, string file, int page, int size)
        {
            PreuploadRetModel ret = null;

            if (response.errno == 0 && response.return_type == 1 && response.block_list != null && response.block_list.Any())
            {
                var param = $"&type=tmpfile&path={path}&uploadid={response.uploadid}&partseq={response.block_list[page]}";
                var url = $"https://d.pcs.baidu.com/rest/2.0/pcs/superfile2?method=upload&access_token={token}" + param;

                //List<FileItem> fileData = new();
                //fileData.Add(new FileItem(file));
                //ret = JsonConvert.DeserializeObject<PreuploadRetModel>(await WebUtils.DoPost(url, new Dictionary<string, string>(), "files", fileData));

                ret = JsonConvert.DeserializeObject<PreuploadRetModel>(await HtmlHelper.PostFiles(url, file, page, size));
            }

            return ret;
        }

        public async static Task<string> FinishUpload(PrecreateModel preupload, string uploadId, string token)
        {
            Dictionary<string, string> dic = new();

            dic.Add("path", preupload.path);
            dic.Add("size", preupload.size + "");
            dic.Add("isdir", "0");
            dic.Add("block_list", preupload.block_list);
            dic.Add("uploadid", uploadId);

            var ret = await HtmlHelper.PostFromUrlencoded($"https://pan.baidu.com/rest/2.0/xpan/file?method=create&access_token={token}", dic);

            return ret;
        }

        /// <summary>  
        /// 获取用户信息
        /// </summary>  
        /// <returns>返回</returns>  
        public async static Task<UInfo> GetUserInfo(string token)
        {
            string url = $"https://pan.baidu.com/rest/2.0/xpan/nas?method=uinfo&access_token={token}";
            var result = JsonConvert.DeserializeObject<UInfo>(await HtmlHelper.Get(url));
            return result;
        }

        /// <summary>  
        /// 获取网盘容量信息
        /// </summary>  
        /// <returns>返回</returns>  
        public async static Task<Quota> Quota(string token)
        {
            string url = $"https://pan.baidu.com/api/quota?";
            url += "access_token=" + token;
            url += "&chckfree=1";
            url += "checkexpire=1";
            var result = JsonConvert.DeserializeObject<Quota>(await HtmlHelper.Get(url));
            return result;

        }
    }

    public class UInfo
    { 
        public string baidu_name { get; set; }
        public string netdisk_name { get; set; }
        public string avatar_url { get; set; }
        public BaiduVipTypeEnum vip_type { get; set; }
        public string uk { get; set; }
    }

    public class Quota
    { 
        public long total { get; set; }
        public long used { get; set; }
        public long free 
        {
            get 
            {
                return total - used;
            } 
        }
        public bool expire { get; set; }
    }

    public enum BaiduVipTypeEnum
    {
        普通用户 = 0,
        普通会员 = 1,
        超级会员 = 2
    }

    public class TokenReturnModel
    {
        //要获取的Access Token
        public string access_token { get; set; }
        //Access Token的有效期，以秒为单位；请参考“Access Token生命周期方案”
        public int expires_in { get; set; }
        //用于刷新Access Token 的 Refresh Token,所有应用都会返回该参数；（10年的有效期）
        public string refresh_token { get; set; }
        //Access Token最终的访问范围，即用户实际授予的权限列表（用户在授权页面时，有可能会取消掉某些请求的权限），关于权限的具体信息参考“权限列表”一节
        public string scope { get; set; }
        //基于http调用Open API时所需要的Session Key，其有效期与Access Token一致
        public string session_key { get; set; }
        //基于http调用Open API时计算参数签名用的签名密钥
        public string session_secret { get; set; }
        public string error { get; set; }
        public string error_description { get; set; }
    }

    public class PrecreateModel
    {
        public string file { get; set; }
        public string file_name { get; set; }
        public string path { get; set; }
        public long size { get; set; }
        public string block_list { get; set; }
        public int part_size { get; set; }
        public int part_count { get; set; }
        public int part_read { get; set; }
        public string content_md5 { get; set; }
        public string slice_md5 { get; set; }
        public string local_ctime { get; set; }
        public string local_mtime { get; set; }
    }

    public class PrecreateRetModel
    {
        //错误码
        public int errno { get; set; }
        //文件的绝对路径
        public string path { get; set; }
        //上传id
        public string uploadid { get; set; }
        //返回类型，1 文件在云端不存在、2 文件在云端已存在
        public int return_type { get; set; }
        //需要上传的分片序号，索引从0开始
        public int[] block_list { get; set; }
    }

    public class PreuploadRetModel
    {
        public int errorno { get; set; }
        public string md5 { get; set; }
        public string request_id { get; set; }
    }
}
