using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SO.SilList.Manager.Managers;
using SO.SilList.Manager.Models.ValueObjects;

namespace SO.SilList.Admin.Web.Controllers
{
    public class BusinessImagesController : Controller
    {
        private BusinessImageManager businessImageManager = new BusinessImageManager();

        public ActionResult Index()
        {
            ViewBag.Title = "Business Images";
            return View();
        }

        public ActionResult _List()
        {
            var results = businessImageManager.getAll();
            return PartialView(results);
        }

        public ActionResult Menu()
        {
            return PartialView("../Business/_Menu");
        }
        [HttpPost]
        public ActionResult Edit(Guid id, BusinessImagesVo input)
        {
            if (this.ModelState.IsValid)
            {
                var res = businessImageManager.update(input, id);
                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult Edit(Guid id)
        {
            var result = businessImageManager.get(id);
            return View(result);
        }

        [HttpPost]
        public ActionResult Create(BusinessImagesVo input)
        {
            if (this.ModelState.IsValid)
            {
                var item = businessImageManager.insert(input);
                BusinessImagesVo ci = new BusinessImagesVo();
                ci.imageId = item.imageId;
                businessImageManager.insert(ci);
                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult Create()
        {
            var c = new BusinessImagesVo();
            return View(c);
        }

        public ActionResult Details(Guid id)
        {
            var result = businessImageManager.get(id);
            return View(result);
        }
        public ActionResult Delete(Guid id)
        {
            businessImageManager.delete(id);
            return RedirectToAction("Index");
        }
    }
}
