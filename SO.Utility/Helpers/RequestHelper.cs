using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SO.Utility.Helpers
{
    public class RequestHelper
    {

        public static string GetQueryString(string key)
        {
            if (Common.GetCurrentRequest.QueryString[key] != null)
                return Common.GetCurrentRequest.QueryString[key].ToString();
            return "";
        }
    }
}
