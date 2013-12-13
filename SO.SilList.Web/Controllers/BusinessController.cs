using SO.SilList.Manager.Managers;
using SO.SilList.Manager.Models.ValueObjects;
using SO.SilList.Manager.Models.ViewModels;
using SO.SilList.Utility.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SO.SilList.Web.Controllers
{
    public class BusinessController : Controller
    {
        private BusinessManager businessManager = new BusinessManager();
        private BusinessCategoriesManager businessCategoryManager = new BusinessCategoriesManager();
        private CityTypeManager cityTypeManager = new CityTypeManager();
        private StateTypeManager stateTypeManager = new StateTypeManager();
        private CountryTypeManager countryTypeManager = new CountryTypeManager();
        //
        // GET: /Rentals/

        public ActionResult Index(BusinessVm input = null, Paging paging = null)
        {
            if (input == null)
                input = new BusinessVm();
            input.isActive = true;
            input.paging = paging;
            if (this.ModelState.IsValid)
            {
                if (input.submitButton != null)
                    input.paging.pageNumber = 1;
                input = businessManager.search(input);
                return View(input);
            }

            return View();
        }

        public ActionResult Filter(BusinessVm input)
        {
            return PartialView("_Filter", input);
        }

        public ActionResult Details(Guid? id = null)
        {
            var idNew = new Guid("2c00a271-da52-49ed-ac5e-c0d8baa1dfb6");
            var result = businessManager.get(idNew);
            return View(result);
        }

        public ActionResult Categories(Guid? id = null)
        {
            var idNew = new Guid("6ebe653d-0a10-44bf-bff6-84e1dbe6e36d");
            var result = businessCategoryManager.get(idNew);
            return PartialView(result);
        }

        public ActionResult Create()
        {
            var vo = new BusinessVo();
            return View(vo);
        }
        [HttpPost]
        public ActionResult Create(BusinessVo input)
        {
            if (this.ModelState.IsValid)
            {
                var item = businessManager.insert(input);

                ImageManager imageManager = new ImageManager();

                imageManager.InsertUploadImages(item.businessId, Request.Files, Server, SO.SilList.Manager.Managers.ImageCategory.businessImage);

                return RedirectToAction("Index");
            }

            return View(input);

        }
        public ActionResult DropDownList(int? id = null, string propertyName = null, Type modelType = null, string defaultValue = null)
        {
            //var item = Activator.CreateInstance(modelType);
            ViewBag.propertyName = propertyName;
            if (defaultValue == null)
                defaultValue = "Select One";
            ViewBag.defaultValue = defaultValue;

            ViewBag.selectedItem = id;
            if (modelType == typeof(CountryTypeVo))
            {
                ViewBag.items = countryTypeManager.getAll(true);
                ViewBag.idName = "countryTypeId";
            }
            else if (modelType == typeof(StateTypeVo))
            {
                ViewBag.items = stateTypeManager.getAll(true);
                ViewBag.idName = "stateTypeId";
            }
            else if (modelType == typeof(CityTypeVo))
            {
                ViewBag.items = cityTypeManager.getAll(true);
                ViewBag.idName = "cityTypeId";
            }

            return PartialView("_DropDownList");
        }

        public ActionResult Pagination(Paging input)
        {
            return PartialView("_Pagination", input);
        }

    }
}
