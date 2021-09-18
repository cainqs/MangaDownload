using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MangaDownload.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            var url = string.Format(@"http://openapi.baidu.com/oauth/2.0/authorize?response_type=code&client_id={0}&redirect_uri={1}&scope=basic,netdisk&display=page&qrcode=1&force_login=1", "YjvPbGLPaeIQN1bMbQE3EDpvVk2jPXQe", "http://www.cainqs.com:22001/Login/ThirdLoginIndex");

            return Redirect(url);
        }

        public IActionResult ThirdLoginIndex(string type)
        {
            //回调参数
            var data = Request.QueryString;
            var code = "";

            if (!string.IsNullOrEmpty(code))
            { 
                
            }


            return View();
        }
    }
}
