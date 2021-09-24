using HtmlAgilityPack;
using MangeDownload.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace Services.Manga
{
    public class IKHMSite : IMangaSite
    {
        public MangaSiteModel siteModel { get; set; }

        public IKHMSite()
        {
            siteModel = new();
            siteModel.ShowTitle = "爱看韩漫";
            siteModel.IndexUrl = "http://www.ikanhm.top/";
            siteModel.SitePrefix = "http://www.ikanhm.top";
            siteModel.SearchUrl = "http://www.ikanhm.top/search?keyword";
            siteModel.HostUrl = "http://www.ikanhm.top/";
            siteModel.Reffer = "";
            siteModel.Tags = new List<MangaSiteTag>() { MangaSiteTag.KoreaH };
        }


        public async Task<List<IMangaInfo>> Search(string mangaName)
        {
            List<IMangaInfo> ret = new();

            if (!string.IsNullOrEmpty(mangaName))
            {
                CookieContainer cc = await HtmlHelper.GetCookieContainer(siteModel.IndexUrl);

                var htmlRet = await HtmlHelper.Get(siteModel.SearchUrl + "=" +mangaName);

                HtmlDocument htmlDocument = new();
                htmlDocument.LoadHtml(htmlRet);

                var itemPath = "//ul[@class='mh-list col7']//li";

                var itemNodes = htmlDocument.DocumentNode.SelectNodes(itemPath);

                if (itemNodes != null)
                {
                    foreach (var item in itemNodes)
                    {
                        IMangaInfo cmi = new IKHMInfo();

                        var urlNode = item.ChildNodes[1].ChildNodes[1].Attributes["href"];
                        var picNode = item.ChildNodes[1].ChildNodes[1].ChildNodes[1].Attributes["style"];
                        var nameNode = item.ChildNodes[1].ChildNodes[3].ChildNodes[1].InnerText.Trim();
                        var lastUpdateStr = item.ChildNodes[1].ChildNodes[3].ChildNodes[5].ChildNodes[3].InnerText.Trim();

                        cmi.mi.Urls = new();
                        cmi.mi.Cc = cc;
                        cmi.mi.MangaSite = siteModel;
                        cmi.mi.MangeUrl = siteModel.SitePrefix + urlNode.Value;
                        cmi.mi.MangaPic = picNode.Value.Replace("background-image: url(", "").Replace(")","");
                        cmi.mi.MangaName = nameNode;
                        cmi.mi.LastUpdateTimeStr = lastUpdateStr;
                        cmi.mi.LastChapter = "未知";
                        ret.Add(cmi);
                    }
                }
            }

            return ret;
        }
    }
}
