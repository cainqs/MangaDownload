using CloudflareSolverRe;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
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

        public static async Task<string> GetCloudFlare(string url)
        {
            var target = new Uri(url);

            var handler = new ClearanceHandler
            {
                MaxTries = 3,
                ClearanceDelay = 3000
            };

            var client = new HttpClient(handler);
            var content = await client.GetStringAsync(target);

            return content;
        }

        public async static Task<string> PostCloudFlare(string url, object message)
        {
            var ret = "";

            var target = new Uri(url);

            var handler = new ClearanceHandler
            {
                MaxTries = 3,
                ClearanceDelay = 3000
            };

            HttpRequestMessage requestMessage = new(HttpMethod.Post, target);

            if (message != null)
            {
                string jsonContent = JsonConvert.SerializeObject(message);
                requestMessage.Content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            }

            using (var client = new HttpClient(handler))
            {
                var response = await client.SendAsync(requestMessage);

                if (response.IsSuccessStatusCode)
                {
                    using var sr = new StreamReader(await response.Content.ReadAsStreamAsync(), Encoding.UTF8);
                    ret = sr.ReadToEnd();
                }
            }

            return ret;
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

        public async static Task<string> PostFromUrlencoded(string url, Dictionary<string, string> data)
        {
            string ret = "";

            using (var client = new HttpClient())
            {
                var content = new FormUrlEncodedContent(data);

                ret = await client.PostAsync(url, content).Result.Content.ReadAsStringAsync();
            }

            return ret;
        }

        public async static Task<string> PostFiles(string url, string filePath, int page, int size)
        {
            string ret = "";

            using (var client = new HttpClient())
            {
                using (var formData = new MultipartFormDataContent())
                {
                    FileStream fs = new(filePath, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new(fs);

                    fs.Seek(size * page, SeekOrigin.Begin);

                    ByteArrayContent content = new(br.ReadBytes(size)) ;
                    formData.Add(content, "files", Path.GetFileName(filePath));

                    var request = new HttpRequestMessage(HttpMethod.Post, url)
                    {
                        Content = formData
                    };

                    var response = await client.SendAsync(request);

                    if (response.IsSuccessStatusCode)
                    {
                        using var sr = new StreamReader(await response.Content.ReadAsStreamAsync(), Encoding.UTF8);
                        ret = sr.ReadToEnd();
                    }
                }
            }

            return ret;
        }

        public async static Task<string> Get(string url)
        {
            var ret = "";

            using (var client = new HttpClient())
            {
                ret = await client.GetStringAsync(url);
            }

            return ret;
        }
    }
}
