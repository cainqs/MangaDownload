using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public class FileUtility
    {
        private const double KBCount = 1024;
        private const double MBCount = KBCount * 1024;
        private const double GBCount = MBCount * 1024;
        private const double TBCount = GBCount * 1024;

        public static string GetAutoSizeString(double size, int roundCount)
        {
            if (KBCount > size)
            {
                return Math.Round(size, roundCount) + "B";
            }
            else if (MBCount > size)
            {
                return Math.Round(size / KBCount, roundCount) + "KB";
            }
            else if (GBCount > size)
            {
                return Math.Round(size / MBCount, roundCount) + "MB";
            }
            else if (TBCount > size)
            {
                return Math.Round(size / GBCount, roundCount) + "GB";
            }
            else
            {
                return Math.Round(size / TBCount, roundCount) + "TB";
            }
        }

        public static string ReplaceInvalidChar(string str)
        {
            return str.Replace("'", "").Replace("?", "").Replace(":", "").Replace("*", "").Replace("|", "").Replace("\\", "").Replace("/", "").Replace("<", "").Replace(">", "").Replace(" （ブルーレイディスク）", "").Replace("（ブルーレイディスク）", "").Replace("・", "").Replace("♪", "").Replace("´", "").Replace("′", "").Replace("｀", "").Replace("◯", "").Replace("?", "").Replace("≪", "").Replace("≫", "").Replace("｢", "").Replace("｣", "").Replace("〜", "").Replace("･", "").Replace("∀", "").Replace("○", "").Replace("～", "").Replace("♯", "").Replace("､", "").Replace("━", "").Replace("ﾟ", "").Replace("｡", "").Replace("⇒", "").Replace("⇔", "").Replace("ｷ", "").Replace("ﾀ", "");
        }

        public static bool HasInvalidChar(string str)
        {
            return str.Contains("'") || str.Contains("?") || str.Contains(":") || str.Contains("*") || str.Contains("|") || str.Contains("\\") || str.Contains("/") || str.Contains("<") || str.Contains(">") || str.Contains(" （ブルーレイディスク）") || str.Contains("（ブルーレイディスク）") || str.Contains("′") || str.Contains("・") || str.Contains("♪") || str.Contains("´") || str.Contains("｀") || str.Contains("◯") || str.Contains("?") || str.Contains("≪") || str.Contains("≫") || str.Contains("｢") || str.Contains("｣") || str.Contains("〜") || str.Contains("･") || str.Contains("∀") || str.Contains("○") || str.Contains("～") || str.Contains("♯") || str.Contains("､") || str.Contains("━") || str.Contains("ﾟ") || str.Contains("｡") || str.Contains("⇒") || str.Contains("⇔") || str.Contains("ｷ") || str.Contains("ﾀ");
        }
    }
}
