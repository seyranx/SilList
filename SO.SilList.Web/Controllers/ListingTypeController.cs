using System;
using System.Collections.Generic;
using SO.SilList.Manager.Managers;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SO.SilList.Manager.Models.ValueObjects;
using SO.SilList.Manager.Models.ViewModels;
using SO.SilList.Utility.Classes;

namespace SO.SilList.Web.Controllers
{
    public class ListingTypeController : Controller
    {
        private ListingTypeManager listingTypeManager = new ListingTypeManager();

        public ActionResult getTopTypes()
        {
            var results = listingTypeManager.getAll(null);
            return PartialView("getTopTypes", results);
        }

    }
}
