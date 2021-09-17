using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public class HtmlHelper
    {
        public async static Task<CookieContainer> GetCookieContainer(string url)
        {
            CookieContainer cookies = new();
            HttpClientHandler handler = new();
            handler.CookieContainer = cookies;

            HttpClient client = new(handler);
            await client.GetAsync(url);

            return cookies;
        }

        public async static Task<string> GetUrlContent(string url, CookieContainer cookie = null)
        {
            HttpClientHandler handler = new();
            CookieContainer cookies = new();

            if (cookie != null)
            {
                handler.CookieContainer = cookie;
            }
            else
            {
                handler.CookieContainer = cookies;
            }

            HttpClient client = new(handler);

            var ret = await client.GetStringAsync(url);

            return ret;
        }

        public async static Task<string> Post(string url, object message)
        {
            string ret = "";

            string jsonContent = JsonConvert.SerializeObject(message);

            using (var client = new HttpClient())
            {
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                ret = await client.PostAsync(url, content).Result.Content.ReadAsStringAsync();
            }

            return ret;
        }
    }
}
