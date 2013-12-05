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
    public class BathroomTypeController : Controller
    {
        private BathroomTypeManager bathroomTypeManager = new BathroomTypeManager();

        //
        // GET: /BathroomType/

        public ActionResult Index(BathroomTypeVm input = null, Paging paging = null)
        {
            if (input == null) input = new BathroomTypeVm();
            input.paging = paging;
            if (this.ModelState.IsValid)
            {
                if (input.submitButton != null)
                    input.paging.pageNumber = 1;
                input = bathroomTypeManager.search(input);
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
            var results = bathroomTypeManager.getAll(null);
            return PartialView(results);
        }

        [HttpPost]
        public ActionResult Create(BathroomTypeVo input)
        {

            if (this.ModelState.IsValid)
            {

                var item = bathroomTypeManager.insert(input);
                return RedirectToAction("Index");
            }


            return View();

        }

        public ActionResult Create()
        {
            var vo = new BathroomTypeVo();
            return View(vo);
        }

        [HttpPost]
        public ActionResult Edit(int id, BathroomTypeVo input)
        {

            if (this.ModelState.IsValid)
            {
                var res = bathroomTypeManager.update(input, id);
                return RedirectToAction("Index");
            }

            return View();

        }
        public ActionResult Edit(int id)
        {
            var result = bathroomTypeManager.get(id);
            return View(result);
        }

        public ActionResult Details(int id)
        {
            var result = bathroomTypeManager.get(id);
            return View(result);
        }

        public ActionResult Delete(int id)
        {
            bathroomTypeManager.delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult DropDownList(int? id = null, string propertyName = null, string defaultValue = null)
        {
            ViewBag.engines = bathroomTypeManager.getAll(null);
            var engine = new BathroomTypeVo();
            if (id != null)
            {
                engine = bathroomTypeManager.get(id.Value);
            }
            if (propertyName == null)
                propertyName = "bathroomTypeId";
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

        public ActionResult Filter(BathroomTypeVm input)
        {
            return PartialView("_Filter", input);
        }

    }
}

