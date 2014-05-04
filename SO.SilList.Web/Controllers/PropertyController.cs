using SO.SilList.Manager.Managers;
using SO.SilList.Manager.Models.ViewModels;
using SO.SilList.Manager.Models.ValueObjects;
using SO.Utility.Classes;
using SO.Utility.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SO.SilList.Web.Controllers
{
    public class PropertyController : Controller
    {
        private PropertyManager propertyManager = new PropertyManager();
        private PropertyTypeManager propertyTypeManager = new PropertyTypeManager();
        private PropertyListingTypeManager propertyListingTypeManager = new PropertyListingTypeManager();

        public ActionResult Index(SearchFilterVm input = null, Paging paging = null)
        {
            if (input == null) input = new SearchFilterVm();
            input.paging = paging;

            if (this.ModelState.IsValid)
            {
                ViewBag.Title = "Properties";
                if (input.submitButton != null)
                    input.paging.pageNumber = 1;
                input = propertyManager.search(input);
                return View(input);
            }
            return View(input);
        }

        //public ActionResult Filter(SearchFilterVm input = null, Paging paging = null)
        //{
        //    return PartialView("_SearchFilter", input);
        //}

        /// <summary>
        /// Create new Property 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(PropertyVo input)
        {
            ViewBag.Title = "Add New Property";

            if (this.ModelState.IsValid)
            {
                var item = propertyManager.insert(input);
                
                return RedirectToAction("Index");
            }

            return View(input);
        }
        
        public ActionResult Create()
        {
            var vo = new PropertyVo();
            return View(vo);
        }

        public ActionResult SelectList(int? id = null, Type propertyType = null)
        {

            if (propertyType == typeof(PropertyTypeVo))
            {
                ViewBag.list = propertyTypeManager.getAll(true);
                ViewBag.propertyId = "propertyTypeId";
                ViewBag.titleName = "Property Type";
                ViewBag.hiddenName = "propertyTypeIdFilter";
            }
            else if (propertyType == typeof(PropertyListingTypeVo))
            {
                ViewBag.list = propertyListingTypeManager.getAll(true);
                ViewBag.propertyId = "propertyListingTypeId";
                ViewBag.titleName = "Listing Type";
                ViewBag.hiddenName = "propertyListingTypeIdFilter";
            }

            return PartialView("_SelectList");
        }

	}
}