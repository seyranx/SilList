using SO.SilList.Manager.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SO.SilList.Admin.Web.Controllers
{
    public class BusinessController : Controller
    {
        private BusinessManager businessManager = new BusinessManager();

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult List()
        {
            var results = businessManager.getAll(null);
            return PartialView(results);
        }

    }
}
