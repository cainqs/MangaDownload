using MangeDownload.Models;
using Models;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Services
{
    public class RabbitMQService
    {
        //Connection
        static IConnection Connection;
        //Channel
        static IModel Channel;

        public static object JsonConvertEncoding { get; private set; }

        static RabbitMQService()
        {
            ConnectionFactory factory = new();

            factory.HostName = "localhost";
            factory.UserName = "admin";
            factory.Password = "admin";
            factory.Port = 21006;

            Connection = factory.CreateConnection();
            Channel = Connection.CreateModel();
        }

        public static bool PublishMessageToServer(string queueName, string message)
        {
            try
            {
                bool durable = true;
                Channel.QueueDeclare(queueName, durable, false, false, null);

                var messageBody = Encoding.UTF8.GetBytes(message);
                Channel.BasicPublish("", queueName, null, messageBody);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async static void DownloadManage()
        {
            try
            {
                Channel.QueueDeclare("MangaQueue", true, false, false, null);
                var consumer = new EventingBasicConsumer(Channel);
                Channel.BasicConsume("MangaQueue", false, consumer);

                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);

                    if (!string.IsNullOrEmpty(message))
                    {
                        var mangaModel = JsonConvert.DeserializeObject<RabbitMQMangaDownloadModel>(message, new JsonSerializerSettings()
                                                                                                      {
                                                                                                          TypeNameHandling = TypeNameHandling.Auto
                                                                                                      });                  

                        if (mangaModel != null)
                        {
                            IMangaInfo mangaInfo = (IMangaInfo)System.Reflection.Assembly.Load(mangaModel.AssmblyString).CreateInstance(mangaModel.TypeName, false);

                            var mi = mangaModel.MangaInfo.mi;

                            var rootFolder = mangaModel.MangaInfo.Download(mangaModel.Folder, mangaModel.DownloadUrls).Result;

                            var zipFolder = @"c:\manga\zip\";

                            if (!Directory.Exists(zipFolder))
                            {
                                Directory.CreateDirectory(zipFolder);
                                Thread.Sleep(10);
                            }

                            var zip = zipFolder + mi.MangaName + ".zip";

                            ZipFile.CreateFromDirectory(rootFolder, zip);

                            var uploadPath = "/apps/上传漫画/" + Path.GetFileName(zip);

                            var ret = BaiduOauthService.FileSizeAndBlockCount(zip);

                            var totalUpload = 0;
                            var currentUpload = 0;

                            var precreateModel = BaiduOauthService.PrecreateMD5(zip, uploadPath);

                            var precreateResponse = BaiduOauthService.Precreate(precreateModel, mangaModel.Token).Result;

                            totalUpload = precreateModel.part_count;

                            while (currentUpload < totalUpload)
                            {
                                var tempResponse = BaiduOauthService.PreUpload(precreateResponse, HttpUtility.UrlEncode(uploadPath), mangaModel.Token, zip, currentUpload, 4 * 1024 * 1024).Result;

                                if (tempResponse != null && tempResponse.request_id != null && !string.IsNullOrEmpty(tempResponse.request_id))
                                {
                                    currentUpload++;
                                }
                            }

                            var messsage = BaiduOauthService.FinishUpload(precreateModel, precreateResponse.uploadid, mangaModel.Token).Result;
                        }
                    }
                };       
            }
            catch
            { 
            
            }
        }
    }
}
