using HtmlAgilityPack;
using MangeDownload.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace Services.Manga
{
    public class _18ComicVipSite : IMangaSite
    {
        public MangaSiteModel siteModel { get; set; }

        public _18ComicVipSite()
        {
            siteModel = new();
            siteModel.ShowTitle = "禁漫天堂";
            siteModel.IndexUrl = "https://18comic.vip/";
            siteModel.SitePrefix = "https://18comic.vip";
            siteModel.SearchUrl = "https://18comic.vip/search/photos?main_tag=0&search_query";
            siteModel.HostUrl = "https://18comic.vip/";
            siteModel.Reffer = "";
            siteModel.Tags = new List<MangaSiteTag>() { MangaSiteTag.KoreaH };
        }


        public async Task<List<IMangaInfo>> Search(string mangaName)
        {
            List<IMangaInfo> ret = new();

            if (!string.IsNullOrEmpty(mangaName))
            {
                var htmlRet = await HtmlHelper.PostCloudFlare(siteModel.SearchUrl + "=" + mangaName, null);

                HtmlDocument htmlDocument = new();
                htmlDocument.LoadHtml(htmlRet);

                var itemPath = "//div[@class='col-xs-6 col-sm-6 col-md-4 col-lg-3 list-col']";

                var itemNodes = htmlDocument.DocumentNode.SelectNodes(itemPath);

                if (itemNodes != null)
                {
                    foreach (var item in itemNodes)
                    {
                        IMangaInfo cmi = new _18ComicVipInfo();
                        cmi.mi.Urls = new();
                        cmi.mi.MangaSite = siteModel;

                        try
                        {
                            var firstA = item.ChildNodes[1].ChildNodes[1];
                            var imageNode = item.ChildNodes[1].ChildNodes[1].ChildNodes[1].ChildNodes[1];
                            var lastChapterTime = item.ChildNodes[1].ChildNodes[7];

                            cmi.mi.MangeUrl = siteModel.SitePrefix + firstA.Attributes["href"].Value.Trim();
                            cmi.mi.MangaPic = imageNode.Attributes["data-original"].Value.Trim();
                            cmi.mi.MangaName = imageNode.Attributes["title"].Value.Trim();
                            cmi.mi.LastChapter = "无信息";
                            cmi.mi.LastUpdateTimeStr = lastChapterTime.InnerText.Trim();
                        }
                        catch
                        { 
                        
                        }

                        ret.Add(cmi);
                    }
                }
            }

            return ret;
        }
    }
}
