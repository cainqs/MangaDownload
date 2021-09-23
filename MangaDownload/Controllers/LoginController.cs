using MangaDownload.Filters;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace MangaDownload.Controllers
{
    public class LoginController : Controller
    {
        [Rights]
        public IActionResult Index()
        {
            if (Request.Cookies.TryGetValue("mangaUser", out string mangaUser))
            {
                if (RedisService.KeyExists(mangaUser))
                {
                    return Redirect("/Home/Index");
                }
            }

            var url = BaiduOauthService.GetOAuthLoginUrl();

            return Redirect(url);
        }

        public IActionResult ThirdLoginIndex(string type)
        {
            var code = Request.Query["code"].ToString();

            if (!string.IsNullOrEmpty(code))
            {
                var token = BaiduOauthService.GetToken(code).Result;

                var mangaUser = Guid.NewGuid().ToString();

                if (RedisService.SetKey(mangaUser, token.access_token, 60 * 60 * 24 * 5))
                {
                    Response.Cookies.Append("mangaUser", mangaUser, new Microsoft.AspNetCore.Http.CookieOptions() { MaxAge = TimeSpan.FromDays(5), Path = "/", Expires = DateTimeOffset.Now.AddDays(5) });
                    return Redirect("/Home/Index");
                }
            }

            return View();
        }
    }
}
