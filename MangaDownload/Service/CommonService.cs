using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MangaDownload.Service
{
    public class CommonService
    {
        public static string GetToken(string cookie)
        {
            return RedisService.GetKey(cookie);
        }
    }
}
