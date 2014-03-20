using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace SO.Utility.Extensions
{
    public static class NameValueCollectionExtensions
    {

        public static Dictionary<string, string> ToDictionary(this NameValueCollection s)
        {
            if (s == null || s.Count==0) return null;
            var list = new Dictionary<string, string>();

           
            foreach (string key in s.Keys)
            {
                list.Add(key, s[key]);
            }
            return list;
        }

    }
}
