using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SO.SilList.Manager.Managers;

namespace SO.SilList.Admin.Web.Controllers
{
    public class ServiceTypeController : Controller
    {
        private ServiceTypeManager serviceTypeManager = new ServiceTypeManager();

        //
        // GET: /ServiceType/

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult List()
        {
            var results = serviceTypeManager.getAll(null);
            return PartialView(results);
        }


        public ActionResult Menu()
        {
            return PartialView("../Business/_Menu");
        }

    }
}
