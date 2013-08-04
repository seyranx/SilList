using SO.SilList.Manager.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SO.SilList.Admin.Web.Controllers
{
    public class BusinessCategoryTypeController : Controller
    {
        private BusinessCategoryTypeManager businessCategoryTypeManager = new BusinessCategoryTypeManager();

        //
        // GET: /BusinessCategoryType/

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult List()
        {
            var results = businessCategoryTypeManager.getAll(null);
            return PartialView(results);
        }


        public ActionResult Menu()
        {
           return PartialView("../Business/_Menu");
        }
    }
}
