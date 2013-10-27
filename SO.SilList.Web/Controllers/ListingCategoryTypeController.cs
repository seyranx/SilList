using System;
using System.Collections.Generic;
using SO.SilList.Manager.Managers;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SO.SilList.Manager.Models.ValueObjects;
using SO.SilList.Manager.Models.ViewModels;
using SO.SilList.Utility.Classes;

namespace SO.SilList.Web.Controllers
{
    public class ListingCategoryTypeController : Controller
    {
        private ListingCategoryTypeManager listingCategoryTypeManager = new ListingCategoryTypeManager();

        public ActionResult getTopCategories()
        {
            var results = listingCategoryTypeManager.getAll(null);
            return PartialView("getTopCategories", results);
        }
    }

}

