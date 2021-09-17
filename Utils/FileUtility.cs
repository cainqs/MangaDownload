using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public class FileUtility
    {
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
