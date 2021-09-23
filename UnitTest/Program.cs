using MangeDownload.Models;
using Newtonsoft.Json;
using Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web;
using Utils;
using System.Linq;
using Models;
using Services.Manga;

namespace UnitTest
{
    class Program
    {
        static void Main(string[] args)
        {
            IMangaSite mangaSite = (IMangaSite)System.Reflection.Assembly.Load("Services").CreateInstance("Services.Manga.Manhua123Site", false);

            var list = mangaSite.Search("姐姐").Result;

            var downloadMangaInfo = list[0];

            downloadMangaInfo.AddAdditionalInfo().Wait();

            RabbitMQService.PublishMessageToServer("MangaQueue", JsonConvert.SerializeObject(new RabbitMQMangaDownloadModel()
            {
                DownloadUrls = downloadMangaInfo.mi.Urls,
                Folder = @"c:\manga",
                MangaInfo = downloadMangaInfo,
                AssmblyString = "Services",
                TypeName = "Services.MangaSite.Manhua123Info"
            }, new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.Auto }));

            //var root = mangaSite.Download(@"c:\manga", manga, manga.Urls).Result;

            //var zip = MangaService.Zip(root, @"c:\manga\zip\" + manga.MangaName + ".zip");

            //var ret = BaiduOauthService.FileSizeAndBlockCount(@"c:\177-俏妞咖啡馆.zip");


            //var totalUpload = 0;
            //var currentUpload = 0;

            //var filePath = @"c:\95 李賢秀…和我去摩鐵吧.pdf";
            //var uploadPath = "/apps/上传漫画/健身教练.zip";
            var token = "121.a336e92f23c52df156f731667674f511.YQl_55QFSUkIthCfZzKXc4pFD5_NbnYu6lPUjQO.uWKRXA";

            //var precreateModel = BaiduOauthService.PrecreateMD5(filePath, uploadPath);

            //var precreateResponse = BaiduOauthService.Precreate(precreateModel, token).Result;

            //totalUpload = precreateModel.part_count;

            //while (currentUpload < totalUpload)
            //{
            //    var tempResponse = BaiduOauthService.PreUpload(precreateResponse, HttpUtility.UrlEncode(uploadPath), token, filePath, currentUpload, 4 * 1024 * 1024).Result;

            //    if (tempResponse != null && tempResponse.request_id != null && !string.IsNullOrEmpty(tempResponse.request_id))
            //    {
            //        currentUpload++;
            //    }
            //}

            //var messsage = BaiduOauthService.FinishUpload(precreateModel, precreateResponse.uploadid, token).Result;

            var ui = BaiduOauthService.GetUserInfo(token).Result;
            var quato = BaiduOauthService.Quota(token).Result;

            Console.WriteLine("按任意键退出");
            Console.ReadKey();
        }
    }
}
