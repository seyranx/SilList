using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SO.SilList.Manager.Managers;
using SO.SilList.Manager.Models.ValueObjects;

namespace SO.SilList.Admin.Web.Controllers
{
    public class AdministrationController : Controller
    {
        private AdminManager adminManager = new AdminManager();

        //
        // GET: /Administration/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Menu()
        {
            return PartialView("_Menu");
        }

        public ActionResult List()
        {
            var results = adminManager.getAll(null);
            return PartialView(results);
        }

        [HttpPost]
        public ActionResult Create(AdminVo input)
        {
            if (this.ModelState.IsValid)
            {
                var item = adminManager.insert(input);
                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult Create()
        {
            return View();
        }
    }
}
