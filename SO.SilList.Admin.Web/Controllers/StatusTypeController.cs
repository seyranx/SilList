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
    public class StatusTypeController : Controller
    {
        //
        // GET: /RentType/

        private StatusTypeManager rentalTypeManager = new StatusTypeManager();

        public ActionResult Index(EntryStatusTypeVm input = null, Paging paging = null)
        {
            if (input == null) input = new EntryStatusTypeVm();
            input.paging = paging;
            if (this.ModelState.IsValid)
            {
                if (input.submitButton != null)
                    input.paging.pageNumber = 1;
                input = rentalTypeManager.search(input);
                return View(input);
            }
            return View();
        }

        public ActionResult List()
        {
            var results = rentalTypeManager.getAll(null);
            return PartialView(results);  //"_List"
        }

        [HttpPost]
        public ActionResult Edit(int id, EntryStatusTypeVo input)
        {
            if (this.ModelState.IsValid)
            {
                var result = rentalTypeManager.update(input, id);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            var result = rentalTypeManager.get(id);
            return View(result);
        }

        [HttpPost]
        public ActionResult Create(EntryStatusTypeVo input)
        {
            if (this.ModelState.IsValid)
            {
                var rentalItem = rentalTypeManager.insert(input);
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
            var result = rentalTypeManager.get(id);
            return View(result);
        }

        public ActionResult Menu()
        {
            return PartialView("../Rental/_Menu");
        }

        public ActionResult Delete(int id)
        {
            rentalTypeManager.delete(id);
            return RedirectToAction("index");
        }

        public ActionResult DropDownList(int? id = null, string propertyName = null, string defaultValue = null)
        {
            ViewBag.rentTypes = rentalTypeManager.getAll(null);
            var rentType = new EntryStatusTypeVo();
            if (id != null)
            {
                rentType = rentalTypeManager.get(id.Value);
            }

            if (propertyName == null)
                propertyName = "rentTypeId";
            ViewBag.propertyName = propertyName;
            if (defaultValue == null)
                defaultValue = "Select One";
            ViewBag.defaultValue = defaultValue;

            return PartialView("_DropDownList", rentType);

        }
        public ActionResult Filter(EntryStatusTypeVm Input)
        {
            return PartialView("_Filter", Input);
        }
        public ActionResult Pagination(Paging input)
        {
            return PartialView("_Pagination", input);
        }
    }
}
