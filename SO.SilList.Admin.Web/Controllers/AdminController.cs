using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SO.SilList.Admin.Web.Attributes;
using SO.SilList.Manager.Managers;
using SO.SilList.Manager.Models.ValueObjects;

namespace SO.SilList.Admin.Web.Controllers
{
    public class AdminController : Controller
    {
        private AdminManager adminManager = new AdminManager();

        //
        // GET: /Administration/

        public ActionResult Index()
        {
        
            return View();
        }

        [DontTrackVisit]
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

        [HttpPost]
        public ActionResult Edit(AdminVo input)
        {
            if (this.ModelState.IsValid)
            {
                var item = adminManager.update(input);
                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult Edit(int id)
        {
            var adminModel = adminManager.get(id);
            return View(adminModel);
        }

        public ActionResult Details(int id)
        {
            var adminModel = adminManager.get(id);
            return View(adminModel);
        }

        [HttpPost]
        public ActionResult Delete(AdminVo input, int id)
        {
            if (this.ModelState.IsValid)
            {
                if (!adminManager.delete(id))
                {
                    ViewBag.Message = "Failed to delete Administrator ID " + id;
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }

            return View();
        }

        public ActionResult Delete(int id)
        {
            var adminModel = adminManager.get(id);
            return View(adminModel);
        }
    }
}
