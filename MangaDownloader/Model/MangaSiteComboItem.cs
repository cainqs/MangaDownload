using MangeDownload.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaDownloader.Model
{
    public class MangaSiteComboItem
    {
        public string ShowTitle { get; set; }
        public string MangaInfoClassPath { get; set; }
        public IMangaSite Tag { get; set; }
    }
}
