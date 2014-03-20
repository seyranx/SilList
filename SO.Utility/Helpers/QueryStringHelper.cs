using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Web;
using SO.Utility.Extensions;

namespace SO.Utility.Helpers
{
    public class QueryStringHelper
    {
        public static string toQueryString(Dictionary<string,string> list)
        {
            NameValueCollection queryString = HttpUtility.ParseQueryString(string.Empty);

            foreach (var key in list.Keys)
            {
                queryString[key] = list[key];
            }
            return queryString.ToString(); // Returns "key1=value1&key2=value2", all URL-encoded
        }

        public static Dictionary<string, string> toDictionary(string queryString)
        {
            NameValueCollection list = HttpUtility.ParseQueryString(queryString);
            return list.ToDictionary();
        }

    }
}
