using MangeDownload.Models;
using Models.MangaSite;
using Services;
using System;
using Utils;

namespace UnitTest
{
    class Program
    {
        static void Main(string[] args)
        {
            IManga mangaSite = (IManga)System.Reflection.Assembly.Load("Models").CreateInstance("Models.MangaSite.Manhua123", false);

            var list = mangaSite.Search("姐姐").Result;

            var manga = mangaSite.AddAdditionalInfo(list[0]).Result;

            var root = mangaSite.Download(@"c:\manga", manga, manga.Urls).Result;

            var zip = MangaService.Zip(root, @"c:\manga\zip\" + manga.MangaName + ".zip");

            Console.WriteLine(zip);
        }
    }
}
