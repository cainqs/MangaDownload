using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MangeDownload.Models
{
    public class MangaInfo
    {
        public string MangaName { get; set; }
        public string MangeUrl { get; set; }
        public int MangaChapters { get; set; }
        public string MangaPic { get; set; }
        public int LastChapter { get; set; }
        public CookieContainer Cc { get; set; }
        public List<(string, string)> Urls { get; set; }
        public MangaSiteModel MangaSite { get; set; }
        public string LastUpdateTimeStr { get; set; }
    }
}
