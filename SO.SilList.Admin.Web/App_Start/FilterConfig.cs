﻿using System.Web;
using System.Web.Mvc;
using SO.SilList.Admin.Web.Attributes;

namespace SO.SilList.Admin.Web
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