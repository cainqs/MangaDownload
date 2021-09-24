using MangeDownload.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utils;

namespace MangaDownload.Models
{
    public class HomePageVM
    {
        public BaiduUserInfo BaiduUserInfo { get; set; }
        public List<MangaSiteDropDown> MangaSites { get; set; }
        public string SelectedSite { get; set; }
        public string SearchContent { get; set; }
    }

    public class BaiduUserInfo
    { 
        public string AvatarUrl { get; set; }
        public string NetDiskName { get; set; }
        public string VipType { get; set; }
        public long TotalSpace { get; set; }
        public long UsedSpace { get; set; }
        public long FreeSpace { get; set; }
        public string TotalSpaceStr
        {
            get
            {
                return FileUtility.GetAutoSizeString(TotalSpace, 1);
            }
        }
        public string UsedSpaceStr
        {
            get
            {
                return FileUtility.GetAutoSizeString(UsedSpace, 1);
            }
        }
        public string FreeSpaceStr
        {
            get
            {
                return FileUtility.GetAutoSizeString(FreeSpace, 1);
            }
        }
    }

    public class MangaSiteDropDown
    { 
        public string ShowTitle { get; set; }
        public string SiteClassPath { get; set; }
    }

    public class DownloadVM
    {
        public List<DetailUrl> urls { get; set; }
        public MangaInfo mi { get; set; }
        public string site { get; set; }
    }

    public class MangaTrasnData
    { 
        public string site { get; set; }
        public string mi { get; set; }
    }
}
