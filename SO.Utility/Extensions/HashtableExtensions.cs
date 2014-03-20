using System.Text;
using System;
using System.Collections;

namespace SO.Utility
{
    public static class HashtableExtensions
    {

        public static string toQueryString(this Hashtable data)
        {
            return HashtableHelper.toQueryString(data);
        }

       

    }
}