using Services;
using System;

namespace MangaDownloadAndUpload
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                RabbitMQService.DownloadManage();
            }
        }
    }
}
