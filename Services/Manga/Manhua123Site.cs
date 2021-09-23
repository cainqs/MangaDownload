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

namespace Services.Manga
{
    public class Manhua123Site : IMangaSite
    {
        public MangaSiteModel siteModel { get; set; }

        public Manhua123Site()
        {
            siteModel = new();
            siteModel.ShowTitle = "漫画123";
            siteModel.IndexUrl = "https://www.manhua123.net/";
            siteModel.SitePrefix = "https://www.manhua123.net";
            siteModel.SearchUrl = "https://www.manhua123.net/search.html";
            siteModel.HostUrl = "https://www.manhua123.net/";
            siteModel.Reffer = "";
            siteModel.Tags = new List<MangaSiteTag>() { MangaSiteTag.General };
        }

        public async Task<List<IMangaInfo>> Search(string mangaName)
        {
            List<IMangaInfo> ret = new();

            if (!string.IsNullOrEmpty(mangaName))
            {
                CookieContainer cc = await HtmlHelper.GetCookieContainer(siteModel.IndexUrl);

                Dictionary<string, string> dic = new();

                dic.Add("keyword", mangaName);

                var htmlRet = await HtmlHelper.Post(siteModel.SearchUrl, dic);

                HtmlDocument htmlDocument = new();
                htmlDocument.LoadHtml(htmlRet);

                var itemPath = "//ul[@id='list_img']//li";

                var itemNodes = htmlDocument.DocumentNode.SelectNodes(itemPath);

                if (itemNodes != null)
                {
                    foreach (var item in itemNodes)
                    {
                        IMangaInfo cmi = new Manhua123Info();
                        cmi.mi.Urls = new();
                        cmi.mi.Cc = cc;
                        cmi.mi.MangaSite = siteModel;
                        var urlNode = item.ChildNodes.FindFirst("a");
                        var picNode = item.ChildNodes.FindFirst("img");
                        var lastChapter = item.ChildNodes[1].ChildNodes[3];
                        var lstUpdateDate = item.ChildNodes[1].ChildNodes[7];
                        var nameNode = item.ChildNodes[1].ChildNodes[5];

                        if (nameNode != null && picNode != null && urlNode != null)
                        {
                            cmi.mi.MangeUrl = siteModel.SitePrefix + urlNode.Attributes["href"].Value.Trim();
                            cmi.mi.MangaName = FileUtility.ReplaceInvalidChar(nameNode.InnerText.Trim());
                            cmi.mi.MangaPic = picNode.Attributes["src"].Value.Trim();
                            cmi.mi.LastChapter = lastChapter.InnerText.Trim();
                            cmi.mi.LastUpdateTimeStr = lstUpdateDate.InnerText.Trim();
                            ret.Add(cmi);
                        }
                    }
                }
            }

            return ret;
        }
    }
}
