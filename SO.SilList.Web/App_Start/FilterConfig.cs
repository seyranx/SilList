using System.Web;
using System.Web.Mvc;
using SO.SilList.Manager.Attributes;

namespace SO.SilList.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new TrackVisitAttribute(1));
        }
    }
}