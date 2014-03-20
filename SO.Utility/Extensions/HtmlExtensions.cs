using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Web.Mvc;
using System.Web.Routing;
using System.ComponentModel;
using System.Web;
using System.Web.Mvc.Html;


namespace SO.Utility
{
    public static class HtmlExtensions
    {

        #region ActionQueryLink

       
        public static string ActionQueryLink(this HtmlHelper htmlHelper,
        string linkText, string action)
        {
            return ActionQueryLink(htmlHelper, linkText, action, null);
        }

         [AspNetHostingPermission(System.Security.Permissions.SecurityAction.LinkDemand, Level = AspNetHostingPermissionLevel.Minimal)]
        public static string ActionQueryLink(this HtmlHelper htmlHelper,
            string linkText, string action, object routeValues)
        {
            var queryString =
                htmlHelper.ViewContext.HttpContext.Request.QueryString;

            var newRoute = routeValues == null
                ? htmlHelper.ViewContext.RouteData.Values
                : new RouteValueDictionary(routeValues);

           
            foreach (string key in queryString.Keys)
            {
                if (!newRoute.ContainsKey(key))
                    newRoute.Add(key, queryString[key].ToString());
            }
            string ret =  HtmlHelper.GenerateLink(htmlHelper.ViewContext.RequestContext,
                htmlHelper.RouteCollection, linkText, null ,
                action, null, newRoute,null);

          // LinkExtensions.ActionLink(

            return ret;
        }

        #endregion

     

    }
}
