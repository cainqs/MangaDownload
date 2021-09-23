using MangaDownload.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MangaDownload.Filters;
using Microsoft.Extensions.Options;
using MangaDownload.Service;
using MangeDownload.Models;
using System.Web;
using Newtonsoft.Json;
using Services;
using Models;

namespace MangaDownload.Controllers
{
    public class HomeController : Controller
    {
        private List<string> MangaSites;

        public HomeController(IOptions<List<string>> mangaSites)
        {
            MangaSites = mangaSites.Value;
        }

        [Rights]
        public IActionResult Index()
        {
            ViewData["Title"] = "首页";

            return View();
        }

        public async Task<JsonResult> GetHomePageVM()
        {
            HomePageVM ret = new();
            ret.MangaSites = new();
            if (Request.Cookies.TryGetValue("mangaUser", out string mangaUser))
            {
                var token = CommonService.GetToken(mangaUser);

                var ui = await HomeService.GetBaiduUserInfo(token);
                ret.BaiduUserInfo = ui;

                foreach (var site in MangaSites)
                {
                    IMangaSite mangaInfo = (IMangaSite)System.Reflection.Assembly.Load("Services").CreateInstance(site, false);

                    if (mangaInfo != null)
                    {
                        ret.MangaSites.Add(new MangaSiteDropDown() { ShowTitle = mangaInfo.siteModel.ShowTitle, SiteClassPath = site });

                        ret.SelectedSite = site;
                    }
                }
            }

            return Json(new { data = ret, success = true });
        }


        public IActionResult Search(string content, string site)
        {
            ViewData["Title"] = "搜索-" + content;
            ViewData.Add("mangaInfoClassPath", site.Replace("Site", "Info"));

            return View();
        }

        public async Task<List<MangaInfo>> GetSearcResult(string content, string site)
        {
            List<MangaInfo> ret = new();
            IMangaSite mangaInfo = (IMangaSite)System.Reflection.Assembly.Load("Services").CreateInstance(site, false);

            if (mangaInfo != null)
            {
                var res = await mangaInfo.Search(content);
                ret = res.Select(x => x.mi).ToList();
            }

            return ret;
        }

        public IActionResult Detail(string site, string mi)
        {
            var jsonStr = HttpUtility.UrlDecode(mi);

            var model = JsonConvert.DeserializeObject<MangaInfo>(jsonStr);

            if (model != null)
            {
                ViewData["Title"] = model.MangaName + "-详情";
                ViewData.Add("mangaInfoClassPath", site);
            }

            return View();
        }

        public async Task<MangaInfo> GetMangaDetail(string site, string mi)
        {
            MangaInfo ret = new();

            IMangaInfo mangaInfo = (IMangaInfo)System.Reflection.Assembly.Load("Services").CreateInstance(site, false);
            var jsonStr = HttpUtility.UrlDecode(mi);

            var model = JsonConvert.DeserializeObject<MangaInfo>(jsonStr);

            if (mangaInfo != null && mi != null)
            {
                mangaInfo.mi = model;

                await mangaInfo.AddAdditionalInfo();

                ret = mangaInfo.mi;
            }

            return ret;
        }

        [HttpPost]
        public JsonResult Download(string jsonStr)
        {
           var entity = JsonConvert.DeserializeObject<DownloadVM>(jsonStr);

            if (entity != null)
            {
                IMangaInfo mangaInfo = (IMangaInfo)System.Reflection.Assembly.Load("Services").CreateInstance(entity.site, false);

                if (mangaInfo != null)
                {
                    mangaInfo.mi = entity.mi;
                    if (Request.Cookies.TryGetValue("mangaUser", out string mangaUser))
                    {
                        var token = CommonService.GetToken(mangaUser);

                        RabbitMQService.PublishMessageToServer("MangaQueue", JsonConvert.SerializeObject(new RabbitMQMangaDownloadModel()
                        {
                            DownloadUrls = entity.urls,
                            Folder = @"c:\manga",
                            MangaInfo = mangaInfo,
                            AssmblyString = "Services",
                            TypeName = entity.site,
                            Token = token
                        }, new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.Auto }));

                        return Json(new { success = true, message = "已经建立下载任务，稍后查看百度网盘" });
                    }
                }
            }

            return Json(new { success = false, message = "建立下载任务失败，稍后重试" });
        }
    }
}
