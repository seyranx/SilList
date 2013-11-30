using SO.SilList.Manager.Managers;
using SO.SilList.Manager.Models.ValueObjects;
using SO.SilList.Manager.Models.ViewModels;
using SO.SilList.Utility.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace SO.SilList.Web.Controllers
{

    public class CarController : Controller
    {
        private CarManager carManager = new CarManager();
        private CityTypeManager cityTypeManager = new CityTypeManager();
        private StateTypeManager stateTypeManager = new StateTypeManager();
        private CountryTypeManager countryTypeManager = new CountryTypeManager();
        private CarColorTypeManager carColorTypeManager = new CarColorTypeManager();
        private CarBodyTypeManager carBodyTypeManager = new CarBodyTypeManager();
        private TransmissionTypeManager transmissionTypeManager = new TransmissionTypeManager();
        private CarDoorTypeManager carDoorTypeManager = new CarDoorTypeManager();
        private CarDriveTypeManager carDriveTypeManager = new CarDriveTypeManager();
        private CarEngineTypeManager carEngineTypeManager = new CarEngineTypeManager();
        private CarFuelTypeManager carFuelTypeManager = new CarFuelTypeManager();
        private MakeTypeManager makeTypeManager = new MakeTypeManager();
        private ModelTypeManager modelTypeManager = new ModelTypeManager();
        //
        // GET: /Car/

        public ActionResult Index(CarVm input = null, Paging paging = null)
        {
            

            if (input == null) input = new CarVm();
            input.isActive = true;
            input.paging = paging;
            if (this.ModelState.IsValid)
            {
                if (input.submitButton != null)
                    input.paging.pageNumber = 1;
                input = carManager.search(input);
                return View(input);
            }
            return View();
        }
        
        public ActionResult Pagination(Paging input)
        {
            return PartialView("_Pagination", input);
        }

        public ActionResult Filter(CarVm input)
        {
            return PartialView("_Filter", input);
        }

        public ActionResult DropDownList(int? id = null, string propertyName = null, Type modelType = null, string defaultValue = null,int? makeTypeId=null)
        {
          //var item = Activator.CreateInstance(modelType);
            ViewBag.propertyName = propertyName;
            if (defaultValue == null)
                defaultValue = "Select One";
            ViewBag.defaultValue = defaultValue;

            ViewBag.selectedItem = id;
            if(modelType == typeof(CarDoorTypeVo))
            {
                ViewBag.items = carDoorTypeManager.getAll(true);
                ViewBag.idName = "carDoorTypeId";
            }
            else if (modelType == typeof(CarBodyTypeVo))
            {
                ViewBag.items = carBodyTypeManager.getAll(true);
                ViewBag.idName = "carBodyTypeId";
            }
            else if (modelType == typeof(CarColorTypeVo))
            {
                ViewBag.items = carColorTypeManager.getAll(true);
                ViewBag.idName = "carColorTypeId";
            }
            else if (modelType == typeof(CarDriveTypeVo))
            {
                ViewBag.items = carDriveTypeManager.getAll(true);
                ViewBag.idName = "carDriveTypeId";
            }
            else if (modelType == typeof(CarEngineTypeVo))
            {
                ViewBag.items = carEngineTypeManager.getAll(true);
                ViewBag.idName = "carEngineTypeId";
            }
            else if (modelType == typeof(CarFuelTypeVo))
            {
                ViewBag.items = carFuelTypeManager.getAll(true);
                ViewBag.idName = "carFuelTypeId";
            }
            else if (modelType == typeof(TransmissionTypeVo))
            {
                ViewBag.items = transmissionTypeManager.getAll(true);
                ViewBag.idName = "transmissionTypeId";
            }
            else if (modelType == typeof(MakeTypeVo))
            {
                ViewBag.items = makeTypeManager.getAll(true);
                ViewBag.idName = "makeTypeId";
                return PartialView("_MakeDropDownList");
            }
            else if (modelType == typeof(ModelTypeVo) || makeTypeId != null)
            {
                if (makeTypeId == null)
                    makeTypeId = -1;
                ViewBag.items = modelTypeManager.getAll(true,makeTypeId);
                ViewBag.idName = "modelTypeId";
            }
            else if (modelType == typeof(CountryTypeVo))
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

        public ActionResult CollapseListModel(int? id = null,int? makeId = null, string propertyName = null)
        {
            ViewBag.selectedId = id;
            ViewBag.propertyName = propertyName;
            if (makeId == null)
                makeId = -1;
                ViewBag.list = modelTypeManager.getAll(true,makeId);
                ViewBag.propertyId = "modelTypeId";
            if (makeId>=0)
                ViewBag.titleName = makeTypeManager.get((int)makeId).name + " Models";
            return PartialView("_CollapseList");
        }

        public ActionResult Detail(Guid id )
        {
            var result = carManager.get(id);

            // Images
            ImageManager imageManager = new ImageManager();
           // ViewBag.Images = imageManager.getCarImages(id);
            ViewBag.ImagesURL = imageManager.getPropertyImagesUrl(id);
            return View(result);
        }
        public ActionResult Create()
        {
            var vo = new CarVo();
            return View(vo);
        }
        [HttpPost]
        public ActionResult Create(CarVo input)
        {
            

            if (this.ModelState.IsValid)
            {
                var item = carManager.insert(input);

                ImageManager imageManager = new ImageManager();
                
                imageManager.InsertUploadImages(item.carId, Request.Files, Server, SO.SilList.Manager.Managers.ImageCategory.carImage);

                return RedirectToAction("Index");
            }


            return View(input);

        }
        public ActionResult CollapseList(int? id = null, string propertyName = null, Type modelType = null)
        {
            ViewBag.selectedId = id;
            ViewBag.propertyName = propertyName;
      
            if (modelType == typeof(MakeTypeVo))
            {
                ViewBag.list = makeTypeManager.getAll(true); 
               // var idList = list.Select(c => c.makeTypeId).ToList();
                ViewBag.propertyId = "makeTypeId";
                ViewBag.titleName = "Make";
            }
            else if (modelType == typeof(CarBodyTypeVo))
            {
                ViewBag.list = carBodyTypeManager.getAll(true);
                ViewBag.propertyId = "carBodyTypeId";
                ViewBag.titleName = "Body";
            }
            else if (modelType == typeof(TransmissionTypeVo))
            {
                ViewBag.list = transmissionTypeManager.getAll(true);
                ViewBag.propertyId = "transmissionTypeId";
                ViewBag.titleName = "Transmission";
            }
            else if (modelType == typeof(CarColorTypeVo))
            {
                ViewBag.list = carColorTypeManager.getAll(true);
                ViewBag.propertyId = "carColorTypeId";
                ViewBag.titleName = "Color";
            }
            else if (modelType == typeof(CarDoorTypeVo))
            {
                ViewBag.list = carDoorTypeManager.getAll(true);
                ViewBag.propertyId = "carDoorTypeId";
                ViewBag.titleName = "Doors";
            }
            else if (modelType == typeof(CarDriveTypeVo))
            {
                ViewBag.list = carDriveTypeManager.getAll(true);
                ViewBag.propertyId = "carDriveTypeId";
                ViewBag.titleName = "Drive Train";
            }
            else if (modelType == typeof(CarEngineTypeVo))
            {
                ViewBag.list = carEngineTypeManager.getAll(true);
                ViewBag.propertyId = "carEngineTypeId";
                ViewBag.titleName = "Engine";
            }
            else if (modelType == typeof(CarFuelTypeVo))
            {
                ViewBag.list = carFuelTypeManager.getAll(true);
                ViewBag.propertyId = "carFuelTypeId";
                ViewBag.titleName = "Fuel";
            }

            return PartialView("_CollapseList");
        }

    }
}
