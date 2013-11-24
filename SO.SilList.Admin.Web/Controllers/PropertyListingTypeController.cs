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
    public class PropertyListingTypeController : Controller
    {
        //
        // GET: /LeaseTermType/

        private PropertyListingTypeManager propertyListingTypeManager = new PropertyListingTypeManager();

        public ActionResult Index(PropertyListingTypeVm input = null, Paging paging = null)
        {
            if (input == null) input = new PropertyListingTypeVm();
            input.paging = paging;
            if (this.ModelState.IsValid)
            {
                if (input.submitButton != null)
                    input.paging.pageNumber = 1;
                input = propertyListingTypeManager.search(input);
                return View(input);
            }
            return View();
        }

        public ActionResult List()
        {
            var results = propertyListingTypeManager.getAll(null);
            return PartialView(results);
        }

        [HttpPost]
        public ActionResult Edit(int id, PropertyListingTypeVo input)
        {
            if (this.ModelState.IsValid)
            {
                var res = propertyListingTypeManager.update(input, id);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            var result = propertyListingTypeManager.get(id);
            return View(result);
        }

        [HttpPost]
        public ActionResult Create(PropertyListingTypeVo input)
        {
            if (this.ModelState.IsValid)
            {

                var item = propertyListingTypeManager.insert(input);
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
            var result = propertyListingTypeManager.get(id);
            return View(result);
        }

        public ActionResult Menu()
        {
            return PartialView("../Property/_Menu");
        }

        public ActionResult Delete(int id)
        {
            propertyListingTypeManager.delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult DropDownList(int? id = null, string propertyName = null, string defaultValue = null)
        {
            ViewBag.propertyListingTypes = propertyListingTypeManager.getAll(null);
            var leaseType = new PropertyListingTypeVo();
            if (id != null)
            {
                leaseType = propertyListingTypeManager.get(id.Value);
            }

            if (propertyName == null)
                propertyName = "propertyListingTypeId";
            ViewBag.propertyName = propertyName;
            if (defaultValue == null)
                defaultValue = "Select One";
            ViewBag.defaultValue = defaultValue;
            return PartialView("_DropDownList", leaseType);
        }

        public ActionResult Filter(PropertyListingTypeVm Input)
        {
            return PartialView("_Filter", Input);
        }

        public ActionResult Pagination(Paging input)
        {
            return PartialView("_Pagination", input);
        }
    }
}
