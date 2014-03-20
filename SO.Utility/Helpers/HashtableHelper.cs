using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Web;

namespace SO.Utility
{
    public class HashtableHelper
    {

        public static string print(Hashtable hash)
        {
            string ret = "";
            foreach (string key in hash.Keys)
                ret += "|" + key + " = " + hash[key].ToString() + "| " + Environment.NewLine;
            return ret;
        }

        public static string toQueryString(Hashtable data)
        {
            List<string> parts = new List<string>();
            foreach (string key in data.Keys)
            {
                string value = "";
                if (data[key] != null) value = data[key].ToString();
                string tag = String.Format("{0}={1}", HttpUtility.UrlEncode(key), HttpUtility.UrlEncode(value));
                parts.Add(tag);
            }
            string ret = string.Join("&", parts.ToArray());
            return ret;
        } 

        
       

    }
}
