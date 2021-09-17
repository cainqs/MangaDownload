using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MangeDownload.Models
{
    public interface IManga
    {
        Task<List<MangaInfo>> Search(string mangaName);

        Task<MangaInfo> AddAdditionalInfo(MangaInfo mangaInfo);

        Task<string> Download(string folder, MangaInfo mangaInfo, List<(string, string)> downloadUrls);
    }
}
