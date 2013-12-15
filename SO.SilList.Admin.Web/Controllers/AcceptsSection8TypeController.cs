using SO.SilList.Manager.Managers;
using SO.SilList.Manager.Models;
using SO.SilList.Manager.Models.ViewModels;
using SO.SilList.Utility.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SO.SilList.Manager.Models.ValueObjects;


namespace SO.SilList.Admin.Web.Controllers
{
    public class AcceptsSection8TypeController : Controller
    {
        private AcceptsSection8TypeManager acceptsSection8TypeManager = new AcceptsSection8TypeManager();

        //
        // GET: /AcceptsSection8Type/

        public ActionResult Index(AcceptsSection8TypeVm input = null, Paging paging = null)
        {
            if (input == null) input = new AcceptsSection8TypeVm();
            input.paging = paging;
            if (this.ModelState.IsValid)
            {
                if (input.submitButton != null)
                    input.paging.pageNumber = 1;
                input = acceptsSection8TypeManager.search(input);
                return View(input);
            }
            return View();
        }

        public ActionResult Menu()
        {
            return PartialView("../Property/_Menu");
        }

        public ActionResult List()
        {
            var results = acceptsSection8TypeManager.getAll(null);
            return PartialView(results);
        }

        [HttpPost]
        public ActionResult Create(AcceptsSection8TypeVo input)
        {

            if (this.ModelState.IsValid)
            {

                var item = acceptsSection8TypeManager.insert(input);
                return RedirectToAction("Index");
            }


            return View();

        }

        public ActionResult Create()
        {
            var vo = new AcceptsSection8TypeVo();
            return View(vo);
        }

        [HttpPost]
        public ActionResult Edit(int id, AcceptsSection8TypeVo input)
        {

            if (this.ModelState.IsValid)
            {
                var res = acceptsSection8TypeManager.update(input, id);
                return RedirectToAction("Index");
            }

            return View();

        }
        public ActionResult Edit(int id)
        {
            var result = acceptsSection8TypeManager.get(id);
            return View(result);
        }

        public ActionResult Details(int id)
        {
            var result = acceptsSection8TypeManager.get(id);
            return View(result);
        }

        public ActionResult Delete(int id)
        {
            acceptsSection8TypeManager.delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult DropDownList(int? id = null, string propertyName = null, string defaultValue = null)
        {
            ViewBag.engines = acceptsSection8TypeManager.getAll(null);
            var engine = new AcceptsSection8TypeVo();
            if (id != null)
            {
                engine = acceptsSection8TypeManager.get(id.Value);
            }
            if (propertyName == null)
                propertyName = "acceptsSection8TypeId";
            ViewBag.propertyName = propertyName;
            if (defaultValue == null)
                defaultValue = "Select One";
            ViewBag.defaultValue = defaultValue;
            return PartialView("_DropDownList", engine);
        }

        public ActionResult Pagination(Paging input)
        {
            return PartialView("_Pagination", input);
        }

        public ActionResult Filter(AcceptsSection8TypeVm input)
        {
            return PartialView("_Filter", input);
        }

    }
}

