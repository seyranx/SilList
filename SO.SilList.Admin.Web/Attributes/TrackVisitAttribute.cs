using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using SO.SilList.Manager.Managers;
using SO.SilList.Manager.Models.ValueObjects;

namespace SO.SilList.Admin.Web.Attributes
{
    public class TrackVisitAttribute : IActionFilter 
    {
        private VisitManager visitManager = new VisitManager();

        private int siteId;

        public TrackVisitAttribute(int siteId)
        {
            this.siteId = siteId;
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            // skip actions markled with DontTrackVisitAttribute
            if (filterContext.ActionDescriptor.ControllerDescriptor.GetCustomAttributes(typeof(DontTrackVisitAttribute), false).Any() ||
                filterContext.ActionDescriptor.GetCustomAttributes(typeof(DontTrackVisitAttribute), false).Any() )
            {
                return;
            }

            VisitVo visit = new VisitVo();

            visit.siteId = this.siteId;

            visit.controller = filterContext.ActionDescriptor.ActionName;
            visit.action = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;

            visit.ipAddress = filterContext.HttpContext.Request.UserHostAddress;
            if (null != filterContext.HttpContext.Request.UrlReferrer)
            {
                visit.referrerUrl = filterContext.HttpContext.Request.UrlReferrer.AbsoluteUri;
            }
            visit.browser =
                filterContext.HttpContext.Request.Browser.Browser + "-" + 
                filterContext.HttpContext.Request.Browser.Version;

            visitManager.insertOrUpdate(visit);
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
        }
    }
}
