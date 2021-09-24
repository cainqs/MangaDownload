using Services;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Topshelf;

namespace MangaDownloadAndUpload
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(x =>
            {
                x.Service<MangaDownloadAndUploadService>(s =>
                {
                    s.ConstructUsing(name => new MangaDownloadAndUploadService());
                    s.WhenStarted(tc => tc.DownloadManage());
                    s.WhenStopped(tc => tc.Stop());
                });
                x.RunAsLocalSystem();
                x.SetDescription("下载并上传漫画");
                x.SetDisplayName("MangaDownloadAndUpload");
                x.SetServiceName("MangaDownloadAndUpload");
                x.StartAutomaticallyDelayed();
            });

        }
    }
}
