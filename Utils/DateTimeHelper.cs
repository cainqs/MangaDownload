using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public class DateTimeHelper
    {
        public static string GetTimeStamp(DateTime time)
        {
            TimeSpan ts = time - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalMilliseconds).ToString();
        }
    }
}
