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

        public ActionResult Edit(Guid id)
        {
            var result = businessManager.get(id);
            return View(result);
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Details(Guid id)
        {
            var result = businessManager.get(id);
            return View(result);
        }

    }
}
