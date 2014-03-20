using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;

using System.Diagnostics;
using SO.Utility.Helpers;

namespace SO.Utility
{
   public class Common
    {

        public static void DebugLine(string str){

            Debug.WriteLine(str);

        }

        public static void DebugTime(string str)
        {
            Debug.WriteLine(str + ": " + DateTime.Now.ToString(DateHelper.LONG_TIME_FORMAT));
        }

        public static void JsInvokeFunction(string funcName)
        {
            Page page = GetCurrentPage;
            if (page == null) return;

            page.ClientScript.RegisterStartupScript(typeof(string), "JS" + funcName, funcName, true);

        }

        public static void JSAlert(string msg)
        {
            HttpResponse Response = GetCurrentResponse;

            if (Response == null) return;
           // GetCurrentPage.ClientScript.RegisterStartupScript(
            Response.Write(string.Format("<script>alert('{0}');</script>", msg));
        }

        public static HttpContext GetCurrent
        {
             get{
            return HttpContext.Current;
             }

        }
        public static Page GetCurrentPage
        {
             get{
            if (HttpContext.Current == null) return null;
            Page page = HttpContext.Current.Handler as Page;
            return page;
                  }
        }
        public static HttpResponse GetCurrentResponse
        {
             get{
            if (GetCurrentPage == null) return null;
            return GetCurrentPage.Response;
            }
        }

        public static HttpRequest GetCurrentRequest

        {
            get{
            if (GetCurrentPage == null) return null;
            return GetCurrentPage.Request;
            }
        }

       public static void Redirect(string url){

           Common.GetCurrentResponse.Redirect(url);

       }


        public static string GetApplicationPath()
        {
            return null;
        }

        public static void Echo(string value)
        {
            GetCurrentResponse.Write(String.Format("<br/>{0}<br/>", value));
        }



        
      



    }
}
