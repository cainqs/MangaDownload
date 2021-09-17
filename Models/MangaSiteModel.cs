using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MangeDownload.Models
{
    public class MangaSiteModel
    {
        public string ShowTitle { get; set; }
        public string IndexUrl { get; set; }
        public string SitePrefix { get; set; }
        public string SearchUrl { get; set; }
        public string DetailUrl { get; set; }
        public string HostUrl { get; set; }
        public string Reffer { get; set; }
        public List<MangaSiteTag> Tags { get; set; }
    }

    public enum MangaSiteTag
    { 
        General = 1,
        JapaneseH = 2,
        KoreaH = 3
    }
}
