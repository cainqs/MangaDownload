using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MangeDownload.Models
{
    public interface IMangaSite
    {
        MangaSiteModel siteModel { get; set; }
        Task<List<IMangaInfo>> Search(string mangaName);
    }

    public interface IMangaInfo
    {
        MangaInfo mi { get; set; }
        Task AddAdditionalInfo();
        Task<string> Download(string folder, List<DetailUrl> downloadUrls, IProgress<(string name, int value)> pbProgress = null, IProgress<string> infoProgress = null);
    }
}
