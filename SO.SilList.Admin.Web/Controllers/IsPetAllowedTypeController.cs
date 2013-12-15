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
    public class IsPetAllowedTypeController : Controller
    {
        private IsPetAllowedTypeManager isPetAllowedTypeManager = new IsPetAllowedTypeManager();

        //
        // GET: /IsPetAllowedType/

        public ActionResult Index(IsPetAllowedTypeVm input = null, Paging paging = null)
        {
            if (input == null) input = new IsPetAllowedTypeVm();
            input.paging = paging;
            if (this.ModelState.IsValid)
            {
                if (input.submitButton != null)
                    input.paging.pageNumber = 1;
                input = isPetAllowedTypeManager.search(input);
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
            var results = isPetAllowedTypeManager.getAll(null);
            return PartialView(results);
        }

        [HttpPost]
        public ActionResult Create(IsPetAllowedTypeVo input)
        {

            if (this.ModelState.IsValid)
            {

                var item = isPetAllowedTypeManager.insert(input);
                return RedirectToAction("Index");
            }


            return View();

        }

        public ActionResult Create()
        {
            var vo = new IsPetAllowedTypeVo();
            return View(vo);
        }

        [HttpPost]
        public ActionResult Edit(int id, IsPetAllowedTypeVo input)
        {

            if (this.ModelState.IsValid)
            {
                var res = isPetAllowedTypeManager.update(input, id);
                return RedirectToAction("Index");
            }

            return View();

        }
        public ActionResult Edit(int id)
        {
            var result = isPetAllowedTypeManager.get(id);
            return View(result);
        }

        public ActionResult Details(int id)
        {
            var result = isPetAllowedTypeManager.get(id);
            return View(result);
        }

        public ActionResult Delete(int id)
        {
            isPetAllowedTypeManager.delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult DropDownList(int? id = null, string propertyName = null, string defaultValue = null)
        {
            ViewBag.engines = isPetAllowedTypeManager.getAll(null);
            var engine = new IsPetAllowedTypeVo();
            if (id != null)
            {
                engine = isPetAllowedTypeManager.get(id.Value);
            }
            if (propertyName == null)
                propertyName = "isPetAllowedTypeId";
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

        public ActionResult Filter(IsPetAllowedTypeVm input)
        {
            return PartialView("_Filter", input);
        }

    }
}
