using SO.SilList.Manager.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SO.SilList.Web.Controllers
{
    public class BusinessController : Controller
    {
        private BusinessManager businessManager = new BusinessManager();
        //
        // GET: /Rentals/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(Guid? id = null)
        {
            var idNew = new Guid("2c00a271-da52-49ed-ac5e-c0d8baa1dfb6");
            var result = businessManager.get(idNew);
            return PartialView(result);
        }

    }
}
