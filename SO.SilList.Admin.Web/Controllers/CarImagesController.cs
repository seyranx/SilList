using SO.SilList.Manager.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SO.SilList.Manager.Models.ValueObjects;
using SO.SilList.Manager.Models.ViewModels;
using SO.SilList.Utility.Classes;

namespace SO.SilList.Admin.Web.Controllers
{
    public class CarImageController : Controller
    {
        private CarImagesManager carImageManager = new CarImagesManager();
        //
        // GET: /CarBodyType/

        public ActionResult Index(CarImagesVm input = null, Paging paging = null)
        {
            if (input == null) input = new CarImagesVm();
            input.paging = paging;
            if (this.ModelState.IsValid)
            {
                if (input.submitButton != null)
                    input.paging.pageNumber = 1;
                input = carImageManager.search(input);
                return View(input);
            }
            return View();
        }

        public ActionResult Menu()
        {
            return PartialView("../Car/_Menu");
        }

        public ActionResult List()
        {
            var results = carImageManager.getAll(null);
            return PartialView(results);
        }

        [HttpPost]
        public ActionResult Create(CarImagesVo input)
        {

            if (this.ModelState.IsValid)
            {

                var item = carImageManager.insert(input);
                return RedirectToAction("Index");
            }


            return View();

        }

        public ActionResult Create()
        {
            var vo = new CarImagesVo();
            return View(vo);
        }

        [HttpPost]
        public ActionResult Edit(Guid id, CarImagesVo input)
        {

            if (this.ModelState.IsValid)
            {
                var res = carImageManager.update(input, id);
                return RedirectToAction("Index");
            }

            return View();

        }
        public ActionResult Edit(Guid id)
        {
            var result = carImageManager.get(id);
            return View(result);
        }

        public ActionResult Details(Guid id)
        {
            var result = carImageManager.get(id);
            return View(result);
        }

        public ActionResult Delete(Guid id)
        {
            carImageManager.delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult DropDownList(Guid? id = null)
        {
            ViewBag.bodies = carImageManager.getAll(null);
            var body = new CarImagesVo();
            if (id != null)
            {
                body = carImageManager.get(id.Value);
            }
            return PartialView("_DropDownList", body);
        }

        public ActionResult Pagination()
        {
            return PartialView("_Pagination");
        }

        public ActionResult Filter(CarImagesVm input)
        {
            return PartialView("_Filter", input);
        }

    }
}
