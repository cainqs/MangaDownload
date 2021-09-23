using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public class MD5Helper
    {
        public static string GenerateMD5(byte[] inputBytes)
        {
            // Use input string to calculate MD5 hash
            using MD5 md5 = MD5.Create();
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            return BitConverter.ToString(hashBytes).Replace("-", "");
        }

        public static string GetFileMD5(string filename)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filename))
                {
                    var hash = md5.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "");
                }
            }
        }

        /// 文件校验段的MD5，校验段对应文件前256KB
        /// </summary>
        /// <param name="fileName">文件绝对路径</param>
        /// <returns>MD5值</returns>
        public static string File_md5_Slice(string path)
        {
            Int32 bytes = 1024 * 256;
            try
            {
                FileStream fs = File.Open(path, FileMode.Open, FileAccess.Read);//读取文件
                if (fs.Length < bytes)
                {
                    fs.Close();
                    return GetFileMD5(path);
                }
                byte[] buffer = new byte[bytes];
                fs.Read(buffer, 0, bytes);
                fs.Close();
                MD5 md5 = new MD5CryptoServiceProvider();
                byte[] retVal = md5.ComputeHash(buffer);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < retVal.Length; i++)
                {
                    sb.Append(retVal[i].ToString("x2"));
                }
                string md5_val = sb.ToString();//BitConverter.ToString(output).Replace("-", "")
                //System.Diagnostics.Debug.WriteLine(md5_val);
                return md5_val;
            }
            catch (Exception ex)
            {
                throw new Exception("Get_File_Md5_Slice() fail,error:" + ex.Message);
            }
        }
    }
}
