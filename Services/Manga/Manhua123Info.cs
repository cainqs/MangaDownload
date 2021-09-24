using HtmlAgilityPack;
using MangeDownload.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace Services.Manga
{
    public class Manhua123Info : IMangaInfo
    {
        public MangaInfo mi { get; set; }

        public Manhua123Info() 
        {
            mi = new MangaInfo();
        }

        public async Task AddAdditionalInfo()
        {
            var htmlRet = await HtmlHelper.GetUrlContent(mi.MangeUrl, mi.Cc);

            if (!string.IsNullOrEmpty(htmlRet))
            {
                HtmlDocument htmlDocument = new();
                htmlDocument.LoadHtml(htmlRet);
                var chapterPath = "//ul[@class='jslist01']//li";
                var infoPath = "//div[@class='info l']//ul//li";

                var chapterNodes = htmlDocument.DocumentNode.SelectNodes(chapterPath);
                var infoNodes = htmlDocument.DocumentNode.SelectNodes(infoPath);

                if (chapterNodes != null)
                {
                    foreach (var node in chapterNodes.Reverse())
                    {
                        var aTag = node.ChildNodes.FindFirst("a");

                        if (aTag != null)
                        {
                            var subUrl = aTag.Attributes["href"].Value.Trim();
                            var title = aTag.InnerHtml.Trim();

                            mi.Urls.Add(new DetailUrl() { Title = title, Url = mi.MangaSite.IndexUrl + subUrl });
                        }
                    }
                }

                if (infoNodes != null && infoNodes.Any() && infoNodes.Count >= 6)
                {
                    mi.LastUpdateTimeStr = infoNodes[5].ChildNodes[1].InnerText;
                }
            }
        }

        public async Task<string> Download(string folder, List<DetailUrl> downloadUrls)
        {
            var rootFolder = MangaService.GenerateFolder(folder, mi.MangaName, downloadUrls.Count);

            foreach (var url in downloadUrls)
            {
                var htmlRet = await HtmlHelper.GetUrlContent(url.Url, mi.Cc);

                if (!string.IsNullOrEmpty(htmlRet))
                {
                    var subFolder = MangaService.GenerateSubFolder(rootFolder + FileUtility.ReplaceInvalidChar(url.Title) + Path.DirectorySeparatorChar);

                    var picUrls = htmlRet.Substring(htmlRet.IndexOf("z_img='") + "z_img='".Length);
                    picUrls = picUrls.Substring(0, picUrls.IndexOf("'"));

                    var pics = JsonConvert.DeserializeObject<List<string>>(picUrls);

                    Dictionary<int, string> picToBeDownloaded = new();

                    var index = 1;

                    foreach (var p in pics)
                    {
                        picToBeDownloaded.Add(index++, "https://img.xpelly.com/" + p);
                    }

                    await Task.Run(() =>
                    {
                        Parallel.ForEach(picToBeDownloaded, new ParallelOptions { MaxDegreeOfParallelism = 10 }, node =>
                        {
                            var pic = node.Value;

                            try
                            {
                                new WebClient().DownloadFile(new Uri(pic), subFolder + node.Key + ".jpg");
                            }
                            catch
                            {

                            }
                        });
                    });
                }
            }

            return rootFolder;
        }
    }
}
