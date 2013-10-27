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
        //public JsonResult Search(string keyword)
        //{
        //    var result = cityTypeManager.search(keyword);
             
        //   var json = Json(result, JsonRequestBehavior.AllowGet);
        //   return json;
        //}
        public ActionResult CollapseList(int? id = null, string propertyName = null, Type modelType = null)
        {
            
            if (modelType == typeof(MakeTypeVo))
            {
                ViewBag.list = makeTypeManager.getAll(true);               
            }
            
            return PartialView("_CollapseList");
        }
        public ActionResult CarColorDropDownList(int? id = null, string propertyName = null, string defaultValue = null)
        {
            ViewBag.colors = carColorTypeManager.getAll(null);
            var color = new CarColorTypeVo();
            if (id != null)
            {
                color = carColorTypeManager.get(id.Value);
            }
            if (propertyName == null)
                propertyName = "carColorTypeId";
            ViewBag.propertyName = propertyName;
            if (defaultValue == null)
                defaultValue = "Select One";
            ViewBag.defaultValue = defaultValue;
            return PartialView("_CarColorDropDownList", color);
        }
        public ActionResult CarBodyDropDownList(int? id = null, string propertyName = null, string defaultValue = null, Type modelType=null)
        {

            if (modelType == typeof(CarBodyTypeVo))
            {

            }

            ViewBag.bodies = carBodyTypeManager.getAll(null);
            var body = new CarBodyTypeVo();
            if (id != null)
            {
                body = carBodyTypeManager.get(id.Value);
            }
            if (propertyName == null)
                propertyName = "carBodyTypeId";
            ViewBag.propertyName = propertyName;
            if (defaultValue == null)
                defaultValue = "Select One";
            ViewBag.defaultValue = defaultValue;
            return PartialView("_CarBodyDropDownList", body);
        }
        public ActionResult TransmissionDropDownList(int? id = null, string propertyName = null, string defaultValue = null)
        {
            ViewBag.transmissions = transmissionTypeManager.getAll(null);
            var transmission = new TransmissionTypeVo();
            if (id != null)
            {
                transmission = transmissionTypeManager.get(id.Value);
            }
            if (propertyName == null)
                propertyName = "transmissionTypeId";
            ViewBag.propertyName = propertyName;
            if (defaultValue == null)
                defaultValue = "Select One";
            ViewBag.defaultValue = defaultValue;
            return PartialView("_TransmissionDropDownList", transmission);
        }
        public ActionResult CarDoorDropDownList(int? id = null, string propertyName = null, string defaultValue = null)
        {
            ViewBag.doors = carDoorTypeManager.getAll(null);
            var door = new CarDoorTypeVo();
            if (id != null)
            {
                door = carDoorTypeManager.get(id.Value);
            }
            if (propertyName == null)
                propertyName = "carDoorTypeId";
            ViewBag.propertyName = propertyName;
            if (defaultValue == null)
                defaultValue = "Select One";
            ViewBag.defaultValue = defaultValue;
            return PartialView("_CarDoorDropDownList", door);
        }
        public ActionResult CarDriveDropDownList(int? id = null, string propertyName = null, string defaultValue = null)
        {
            ViewBag.drives = carDriveTypeManager.getAll(null);
            var drive = new CarDriveTypeVo();
            if (id != null)
            {
                drive = carDriveTypeManager.get(id.Value);
            }
            if (propertyName == null)
                propertyName = "carDriveTypeId";
            ViewBag.propertyName = propertyName;
            if (defaultValue == null)
                defaultValue = "Select One";
            ViewBag.defaultValue = defaultValue;
            return PartialView("_CarDriveDropDownList", drive);
        }
        public ActionResult CarEngineDropDownList(int? id = null, string propertyName = null, string defaultValue = null)
        {
            ViewBag.engines = carEngineTypeManager.getAll(null);
            var engine = new CarEngineTypeVo();
            if (id != null)
            {
                engine = carEngineTypeManager.get(id.Value);
            }
            if (propertyName == null)
                propertyName = "carEngineTypeId";
            ViewBag.propertyName = propertyName;
            if (defaultValue == null)
                defaultValue = "Select One";
            ViewBag.defaultValue = defaultValue;
            return PartialView("_CarEngineDropDownList", engine);
        }
        public ActionResult CarFuelDropDownList(int? id = null, string propertyName = null, string defaultValue = null)
        {
            ViewBag.Fuels = carFuelTypeManager.getAll(null);
            var fuel = new CarFuelTypeVo();
            if (id != null)
            {
                fuel = carFuelTypeManager.get(id.Value);
            }
            if (propertyName == null)
                propertyName = "carFuelTypeId";
            ViewBag.propertyName = propertyName;
            if (defaultValue == null)
                defaultValue = "Select One";
            ViewBag.defaultValue = defaultValue;
            return PartialView("_CarFuelDropDownList", fuel);
        }
        public ActionResult MakeDropDownList(int? id = null, string propertyName = null, string defaultValue = null)
        {
            ViewBag.makes = makeTypeManager.getAll(null);
            var make = new MakeTypeVo();
            if (id != null)
            {
                make = makeTypeManager.get(id.Value);
            }
            if (propertyName == null)
                propertyName = "makeTypeId";
            ViewBag.propertyName = propertyName;
            if (defaultValue == null)
                defaultValue = "Select One";
            ViewBag.defaultValue = defaultValue;
            return PartialView("_MAkeDropDownList", make);
        }
        public ActionResult ModelDropDownList(int? id = null, int? _makeTypeId = 0, string propertyName = null, string defaultValue = null)
        {
            ViewBag.models = modelTypeManager.getAll(null, _makeTypeId);
            var model = new ModelTypeVo();
            if (id != null)
            {
                model = modelTypeManager.get(id.Value);
            }
            if (propertyName == null)
                propertyName = "modelTypeId";
            ViewBag.propertyName = propertyName;
            if (defaultValue == null)
                defaultValue = "Select One";
            ViewBag.defaultValue = defaultValue;
            return PartialView("_ModelDropDownList", model);
        }


    }
}
