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
using Microsoft.Extensions.Configuration;

namespace MangaDownload.Controllers
{
    public class HomeController : Controller
    {

        private readonly IConfiguration _config;

        public HomeController(IConfiguration config)
        {
            this._config = config;
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

                IConfigurationSection myArraySection = _config.GetSection("MangaSite");
                var MangaSites = myArraySection.GetChildren().ToArray().Select(x => x.Value).ToList();

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

        public JsonResult DetailPost(string entity)
        {
            var model = JsonConvert.DeserializeObject<MangaTrasnData>(entity);

            TempData["site"] = model.site;
            TempData["mi"] = model.mi;

            return Json(new { success = true });
        }

        public IActionResult Detail()
        {
            var site = TempData["site"].ToString();
            var mi = TempData["mi"].ToString();

            var model = JsonConvert.DeserializeObject<MangaInfo>(mi);

            if (model != null)
            {
                TempData["site"] = site;
                TempData["mi"] = mi;

                ViewData["Title"] = model.MangaName + "-详情";
                ViewData.Add("mangaInfoClassPath", site);
            }

            return View();
        }

        [HttpPost]
        public async Task<MangaInfo> GetMangaDetail(string entity)
        {
            var entityObject = JsonConvert.DeserializeObject<MangaTrasnData>(entity);

            var model = JsonConvert.DeserializeObject<MangaInfo>(entityObject.mi);

            MangaInfo ret = new();

            IMangaInfo mangaInfo = (IMangaInfo)System.Reflection.Assembly.Load("Services").CreateInstance(entityObject.site, false);

            if (mangaInfo != null && model != null)
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
