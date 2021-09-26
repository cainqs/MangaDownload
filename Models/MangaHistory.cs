using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class MangaHistory
    {
        public string MangaSite { get; set; }
        public string MangaName { get; set; }
        public string LastDownloadTimeStr { get; set; }
        public string Downloaded { get; set; }
        public string MangaUrl { get; set; }
        public DateTime LastDownloadTime
        {
            get
            {
                return DateTime.Parse(LastDownloadTimeStr);
            }
        }
        public List<string> DownloadedChapter
        {
            get
            {
                return Downloaded.Split(',').Where(x => !string.IsNullOrEmpty(x)).Distinct().ToList();
            }
        }
    }
}
