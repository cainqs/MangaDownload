using HtmlAgilityPack;
using MangeDownload.Models;
using Newtonsoft.Json;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Utils;

namespace Models.MangaSite
{
    public class Manhua123 : IManga
    {
        private MangaSiteModel siteModel;

        public Manhua123()
        {
            siteModel = new MangaSiteModel();
            siteModel.ShowTitle = "漫画123";
            siteModel.IndexUrl = "https://www.manhua123.net/";
            siteModel.SitePrefix = "https://www.manhua123.net";
            siteModel.SearchUrl = "https://www.manhua123.net/search.html";
            siteModel.HostUrl = "https://www.manhua123.net/";
            siteModel.Reffer = "";
            siteModel.Tags = new List<MangaSiteTag>() { MangaSiteTag.General };
        }

        public async Task<List<MangaInfo>> Search(string mangeName)
        {
            List<MangaInfo> ret = new();
            CookieContainer cc = await HtmlHelper.GetCookieContainer(siteModel.IndexUrl);

            Dictionary<string, string> dic = new();

            dic.Add("keyword", mangeName);

            var htmlRet = await HtmlHelper.Post(siteModel.SearchUrl, dic);

            HtmlDocument htmlDocument = new();
            htmlDocument.LoadHtml(htmlRet);

            var itemPath = "//ul[@id='list_img']//li";

            var itemNodes = htmlDocument.DocumentNode.SelectNodes(itemPath);

            if (itemNodes != null)
            {
                foreach (var item in itemNodes)
                {
                    MangaInfo cmi = new();
                    cmi.Urls = new();
                    cmi.Cc = cc;
                    cmi.MangaSite = siteModel;
                    var urlNode = item.ChildNodes.FindFirst("a");
                    var picNode = item.ChildNodes.FindFirst("img");
                    var nameNode = item.ChildNodes[1].ChildNodes[5];

                    if (nameNode != null && picNode != null && urlNode != null)
                    {
                        cmi.MangeUrl = siteModel.SitePrefix + urlNode.Attributes["href"].Value.Trim();
                        cmi.MangaName = FileUtility.ReplaceInvalidChar(nameNode.InnerText.Trim());
                        cmi.MangaPic = picNode.Attributes["src"].Value.Trim();

                        ret.Add(cmi);
                    }
                }
            }

            return ret;
        }

        public async Task<MangaInfo> AddAdditionalInfo(MangaInfo mangaInfo)
        {
            var htmlRet = await HtmlHelper.GetUrlContent(mangaInfo.MangeUrl, mangaInfo.Cc);

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

                            mangaInfo.Urls.Add((title, mangaInfo.MangaSite.IndexUrl + subUrl));
                        }
                    }
                }

                if (infoNodes != null && infoNodes.Any() && infoNodes.Count >= 6)
                {
                    mangaInfo.LastUpdateTimeStr = infoNodes[5].ChildNodes[1].InnerText;
                }

                return mangaInfo;
            }

            return null;
        }

        public async Task<string> Download(string folder, MangaInfo mangaInfo, List<(string, string)> downloadUrls)
        {
            var rootFolder = MangaService.GenerateFolder(folder, mangaInfo.MangaName, downloadUrls.Count);

            foreach (var url in downloadUrls)
            {
                var htmlRet = await HtmlHelper.GetUrlContent(url.Item2, mangaInfo.Cc);

                if (!string.IsNullOrEmpty(htmlRet))
                {
                    var subFolder = MangaService.GenerateSubFolder(rootFolder + FileUtility.ReplaceInvalidChar(url.Item1) + "\\");

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
