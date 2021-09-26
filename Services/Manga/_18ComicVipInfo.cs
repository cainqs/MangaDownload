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
    class _18ComicVipInfo : IMangaInfo
    {
        public MangaInfo mi { get; set; }

        public _18ComicVipInfo()
        {
            mi = new MangaInfo();
        }

        public async Task AddAdditionalInfo()
        {
            var htmlRet = await HtmlHelper.GetCloudFlare(mi.MangeUrl);

            if (!string.IsNullOrEmpty(htmlRet))
            {
                HtmlDocument htmlDocument = new();
                htmlDocument.LoadHtml(htmlRet);
                var chapterPath = "//div[@id='episode-block']//ul//a";

                var chapterNodes = htmlDocument.DocumentNode.SelectNodes(chapterPath);

                if (chapterNodes != null)
                {
                    foreach (var node in chapterNodes)
                    {
                        var subUrl = node.Attributes["href"].Value.Trim();
                        var name = node.ChildNodes[1].InnerHtml.Trim();

                        if (name.Contains("<span"))
                        {
                            name = name.Substring(0, name.IndexOf("<"));
                        }

                        var title = name.Replace("\n", "");

                        mi.Urls.Add(new DetailUrl() { Title = title, Url = mi.MangaSite.SitePrefix + subUrl });
                    }
                }
            }
        }

        public async Task<string> Download(string folder, List<DetailUrl> downloadUrls, IProgress<(string name, int value)> pbProgress = null, IProgress<string> infoProgress = null)
        {
            var rootFolder = "";

            try
            {
                rootFolder = MangaService.GenerateFolder(folder, mi.MangaName, downloadUrls.Count);
                int chapterIndex = 1;

                if (pbProgress != null)
                {
                    pbProgress.Report(("totalmax", downloadUrls.Count));
                }

                foreach (var url in downloadUrls)
                {
                    var htmlRet = await HtmlHelper.GetCloudFlare(url.Url);

                    if (!string.IsNullOrEmpty(htmlRet))
                    {
                        var subFolder = MangaService.GenerateSubFolder(rootFolder + FileUtility.ReplaceInvalidChar(url.Title) + Path.DirectorySeparatorChar);

                        List<string> pics = new();
                        HtmlDocument htmlDocument = new();
                        htmlDocument.LoadHtml(htmlRet);
                        var picPath = "//div[@class='row thumb-overlay-albums']//div";

                        var picNode = htmlDocument.DocumentNode.SelectNodes(picPath);

                        foreach (var pic in picNode)
                        {
                            if (pic.Attributes["style"] != null && pic.Attributes["style"].Value.Trim() == "text-align:center;")
                            {
                                if (pic.ChildNodes.Count >= 5)
                                {
                                    var imgUrl = pic.ChildNodes[3].Attributes["data-original"].Value.Trim();

                                    pics.Add(imgUrl.Substring(0, imgUrl.IndexOf("?")));
                                }
                            }
                        }

                        Dictionary<int, string> picToBeDownloaded = new();

                        var index = 1;

                        foreach (var p in pics)
                        {
                            picToBeDownloaded.Add(index++, p);
                        }

                        int picIndex = 1;
                        pbProgress.Report(("currentmax", picToBeDownloaded.Count));

                        await Task.Run(() =>
                        {
                            Parallel.ForEach(picToBeDownloaded, new ParallelOptions { MaxDegreeOfParallelism = 5 }, node =>
                            {
                                var pic = node.Value;

                                try
                                {
                                    using var client = new WebClient();
                                    client.DownloadFile(new Uri(pic), subFolder + node.Key + ".jpg");

                                    if (pbProgress != null)
                                    {
                                        pbProgress.Report(("currentvalue", picIndex++));
                                    }
                                }
                                catch (Exception ee)
                                {
                                    if (infoProgress != null)
                                    {
                                        infoProgress.Report(ee.ToString());
                                    }
                                }
                            });
                        });
                    }

                    if (infoProgress != null)
                    {
                        infoProgress.Report($"下载{url.Title}完成");
                    }

                    if (pbProgress != null)
                    {
                        pbProgress.Report(("totalvalue", chapterIndex++));
                    }
                }
            }
            catch (Exception ee)
            {
                if (infoProgress != null)
                {
                    infoProgress.Report(ee.ToString());
                }
            }

            return rootFolder;
        }
    }
}
