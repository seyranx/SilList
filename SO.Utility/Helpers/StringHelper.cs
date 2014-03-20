using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SO.Utility.Helpers
{
    public class StringHelper
    {

        public static string getBetween(string str, string start, string end)
        {

            try
            {

                int startIndex = str.IndexOf(start);
                int endIndex = str.IndexOf(end, startIndex + 1);
                int skip = str.IndexOf(start) + start.Length;

                if (startIndex != -1 && endIndex != -1 && skip <= endIndex)
                {
                    return str.Substring(skip, endIndex - skip);
                }

            }
            catch { }

            return null;
        }
    }
}
