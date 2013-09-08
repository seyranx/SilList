using SO.SilList.Manager.Managers;
using SO.SilList.Manager.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SO.SilList.Manager.Models.ViewModels;

namespace SO.SilList.Admin.Web.Controllers
{
    public class BusinessCategoryTypeController : Controller
    {
        private BusinessCategoryTypeManager businessCategoryTypeManager = new BusinessCategoryTypeManager();

        //
        // GET: /BusinessCategoryType/

        public ActionResult Index(BusinessCategoryTypeVm input = null)
        {
            if (input == null)
                input = new BusinessCategoryTypeVm();
            if (this.ModelState.IsValid)
            {
                input.result = businessCategoryTypeManager.search(input);
                return View(input);
            }
            return View();
        }
        public ActionResult Filter(BusinessCategoryTypeVm Input)
        {
            return PartialView("_Filter", Input);
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

        public ActionResult List()
        {
            var results = businessCategoryTypeManager.getAll(null);
            return PartialView(results);
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

        public ActionResult Details(int id)
        {
            var result = businessCategoryTypeManager.get(id);
            return View(result);
        }

        public ActionResult Menu()
        {
            return PartialView("../Business/_Menu");
        }

        public ActionResult Pagination()
        {
            return PartialView("_Pagination");
        }
        
        public ActionResult Delete(int id)
        {
            businessCategoryTypeManager.delete(id);
            return RedirectToAction("Index");
        }
    }
}
