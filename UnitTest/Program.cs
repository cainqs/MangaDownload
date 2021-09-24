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
            IMangaSite mangaSite = (IMangaSite)System.Reflection.Assembly.Load("Services").CreateInstance("Services.Manga.IKHMSite", false);

            var list = mangaSite.Search("傀儡").Result;

            var downloadMangaInfo = list[0];

            downloadMangaInfo.AddAdditionalInfo().Wait();

            downloadMangaInfo.Download(@"C:\manga", downloadMangaInfo.mi.Urls.Take(3).ToList());

            Console.WriteLine("按任意键退出");
            Console.ReadKey();
        }
    }
}
