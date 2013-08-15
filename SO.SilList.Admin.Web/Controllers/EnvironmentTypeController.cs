using SO.SilList.Manager.Managers;
using SO.SilList.Manager.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SO.SilList.Admin.Web.Controllers
{
    public class EnvironmentTypeController : Controller
    {

        private EnvironmentTypeManager environmentTypeManager = new EnvironmentTypeManager();

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult List()
        {
            var results = environmentTypeManager.getAll(null);
            return PartialView(results);
        }

        [HttpPost]
        public ActionResult Edit(int id, EnvironmentTypeVo input)
        {

            if (this.ModelState.IsValid)
            {
                var res = environmentTypeManager.update(input, id);
                return RedirectToAction("Index");
            }

            return View();
        }


        public ActionResult Edit(int id)
        {
            var result = environmentTypeManager.get(id);
            return View(result);
        }

        [HttpPost]
        public ActionResult Create(EnvironmentTypeVo input)
        {

            if (this.ModelState.IsValid)
            {

                var item = environmentTypeManager.insert(input);
                return RedirectToAction("Index");
            }


            return View();

        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            var result = environmentTypeManager.get(id);
            return View(result);
        }

        public ActionResult Menu()
        {
            return PartialView("_Menu");
        }

        public ActionResult Delete(int id)
        {
            environmentTypeManager.delete(id);
            return RedirectToAction("Index");
        }

    }
}
