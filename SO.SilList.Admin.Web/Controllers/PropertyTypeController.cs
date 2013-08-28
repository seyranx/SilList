using SO.SilList.Manager.Managers;
using SO.SilList.Manager.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SO.SilList.Admin.Web.Controllers
{
    public class PropertyTypeController : Controller
    {
        //
        // GET: /PropertyType/


        private PropertyTypeManager propertyTypeManager = new PropertyTypeManager();

        public ActionResult Index()
        {
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
            return PartialView("../Rental/_Menu");
        }

        public ActionResult Delete(int id)
        {
            propertyTypeManager.delete(id);
            return RedirectToAction("index");
        }

        public ActionResult DropDownList(int? id = null)
        {
            ViewBag.propertyType = propertyTypeManager.getAll(null);
            var propertyType = new PropertyTypeVo();
            if (id != null)
            {
                propertyType = propertyTypeManager.get(id.Value);
            }
            return PartialView("_DropDownList", propertyType);
        }
    }
}
