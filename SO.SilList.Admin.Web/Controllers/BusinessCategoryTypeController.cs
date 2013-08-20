using SO.SilList.Manager.Managers;
using SO.SilList.Manager.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SO.SilList.Admin.Web.Controllers
{
    public class BusinessCategoryTypeController : Controller
    {
        private BusinessCategoryTypeManager businessCategoryTypeManager = new BusinessCategoryTypeManager();

        //
        // GET: /BusinessCategoryType/

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult List()
        {
            var results = businessCategoryTypeManager.getAll(null);
            return PartialView(results);
        }


        public ActionResult Menu()
        {
           return PartialView("../Business/_Menu");
        }

        [HttpPost]
        public ActionResult Create(BusinessCategoryTypeVo input)
        {

            if (this.ModelState.IsValid)
            {

                var item = businessCategoryTypeManager.insert(input);
                return RedirectToAction("Index");
            }


            return View();

        }

        public ActionResult Create()
        {
            var vo = new BusinessCategoryTypeVo();
            return View(vo);
        }

        [HttpPost]
        public ActionResult Edit(int id, BusinessCategoryTypeVo input)
        {

            if (this.ModelState.IsValid)
            {
                var res = businessCategoryTypeManager.update(input, id);
                return RedirectToAction("Index");
            }

            return View();

        }
        public ActionResult Edit(int id)
        {
            var result = businessCategoryTypeManager.get(id);
            return View(result);
        }

        public ActionResult Details(int id)
        {
            var result = businessCategoryTypeManager.get(id);
            return View(result);
        }

        public ActionResult Delete(int id)
        {
            businessCategoryTypeManager.delete(id);
            return RedirectToAction("Index");
        }
    }
}
