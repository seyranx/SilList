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
    public class PropertyTypeController : Controller
    {

        private PropertyTypeManager propertyTypeManager = new PropertyTypeManager();

        public ActionResult Index(PropertyTypeVm input = null, Paging paging = null)
        {
            if (input == null) input = new PropertyTypeVm();
            input.paging = paging;
            if (this.ModelState.IsValid)
            {
                if (input.submitButton != null)
                    input.paging.pageNumber = 1;
                input = propertyTypeManager.search(input);
                return View(input);
            }
            return View();
        }

        public ActionResult List()
        {
            var results = propertyTypeManager.getAll(null);
            return PartialView(results);
        }

        [HttpPost]
        public ActionResult Edit(int id, PropertyTypeVo input)
        {
            if (this.ModelState.IsValid)
            {
                var result = propertyTypeManager.update(input, id);
                    return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            var result = propertyTypeManager.get(id);
                return View(result);
        }

        [HttpPost]
        public ActionResult Create(PropertyTypeVo input)
        {
            if(this.ModelState.IsValid)
            {
                var rentalItem = propertyTypeManager.insert(input);
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
            var result = propertyTypeManager.get(id);
            return View(result);
        }

        public ActionResult Menu()
        {
            return PartialView("../Property/_Menu");
        }

        public ActionResult Delete(int id)
        {
            propertyTypeManager.delete(id);
            return RedirectToAction("index");
        }

        public ActionResult DropDownList(int? id = null, string propertyName = null, string defaultValue = null)
        {
            ViewBag.propertyTypes = propertyTypeManager.getAll(null);
            var propertyType = new PropertyTypeVo();
            if (id != null)
            {
                propertyType = propertyTypeManager.get(id.Value);
            }
            if (propertyName == null)
                propertyName = "propertyTypeId";
            ViewBag.propertyName = propertyName;
            if (defaultValue == null)
                defaultValue = "Select One";
            ViewBag.defaultValue = defaultValue;
            return PartialView("_DropDownList", propertyType);
        }

        public ActionResult Filter(PropertyTypeVm Input)
        {
            return PartialView("_Filter", Input);
        }

        public ActionResult Pagination(Paging input)
        {
            return PartialView("_Pagination", input);
        }
    }
}
