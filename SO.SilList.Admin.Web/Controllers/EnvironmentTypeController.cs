using SO.SilList.Manager.Managers;
using SO.SilList.Manager.Models.ValueObjects;
using SO.SilList.Manager.Models.ViewModels;
using SO.SilList.Utility.Classes;
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

        public ActionResult Index(EnvironmentTypeVm input = null, Paging paging = null)
        {
            if (input == null) input = new EnvironmentTypeVm();
            input.paging = paging;
            if (this.ModelState.IsValid)
            {
                if (input.submitButton != null)
                    input.paging.pageNumber = 1;
                input = environmentTypeManager.search(input);
                return View(input);
            }
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
        public ActionResult Filter(EnvironmentTypeVm Input)
        {
            return PartialView("_Filter", Input);
        }

        public ActionResult Menu()
        {
            return PartialView("_Menu");
        }
        public ActionResult Pagination(Paging input)
        {
            return PartialView("_Pagination", input);
        }

        public ActionResult Delete(int id)
        {
            environmentTypeManager.delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult DropDownList(int? id = null)
        {
            ViewBag.environmentTypes = environmentTypeManager.getAll(null);
            var environmentType = new EnvironmentTypeVo();
            if (id != null)
            {
                environmentType = environmentTypeManager.get(id.Value);
            }
            return PartialView("_DropDownList", environmentType);
        }

    }
}
