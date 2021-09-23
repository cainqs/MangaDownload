using MangeDownload.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class RabbitMQMangaDownloadModel
    {
        public string AssmblyString { get; set; }
        public string TypeName { get; set; }
        public string Folder { get; set; }
        public IMangaInfo MangaInfo { get; set; }
        public List<DetailUrl> DownloadUrls { get; set; }
        public string Token { get; set; }
    }
}
