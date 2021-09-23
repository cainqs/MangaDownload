using Microsoft.AspNetCore.Mvc.Filters;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MangaDownload.Filters
{
    public class RightsAttribute : ActionFilterAttribute
    { 
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Request.Cookies.TryGetValue("mangaUser", out string mangaUser))
            {
                if (!RedisService.KeyExists(mangaUser))
                {
                    context.HttpContext.Response.Redirect("/Login/Index");
                }
            }
            else
            {
                context.HttpContext.Response.Redirect("/Login/Index");
            }
        }
    }
}
