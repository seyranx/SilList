using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SO.Utility.Helpers
{
    public class DateHelper
    {
        //msdn.microsoft.com/en-us/library/8kb3ddd4(VS.71).aspx
        public static string LONG_DATE_FORMAT = "d/M/yyyy HH:mm:ss";
        public static string LONG_TIME_FORMAT = "HH:mm:ss";
        public static string SHORT_DATE_FORMAT = "MM/dd/yyyy";
        public static string MONTH_YEAR_FORMAT = "MMMM yyyy";
        public static string FULL_SQL_DATETIME_WITH_ZONE = "r";// ei: Fri, 16 Dec 2011 16:35:11 GMT   (RFC822 format)
        public static string SQL_DATETIME_FORMAT = "yyyy-MM-dd HH:mm:ss";   //2011-12-16 10:39:12.147
    }
}
