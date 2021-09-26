using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaDownloader.Model
{
    public class MangaHistoryComboItem
    {
        public string MangaName { get; set; }
        public MangaHistory Tag { get; set; }
    }
}
