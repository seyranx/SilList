using SO.SilList.Manager.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SO.SilList.Manager.Models.ValueObjects;
using SO.SilList.Manager.Models.ViewModels;

namespace SO.SilList.Admin.Web.Controllers
{
    public class BusinessController : Controller
    {
        private BusinessManager businessManager = new BusinessManager();

        public ActionResult Index()
        {
            var vo = new BusinessVm();
            return View(vo);
        }

        public ActionResult Search(BusinessVm input)
        {

            if (this.ModelState.IsValid)
            {
                input.result = businessManager.search(input);
                return View("Index", input);
            }

            return View("Index");

        }
        public ActionResult Filter(BusinessVm input)
        {
            return PartialView("_Filter", input);
        }

        public ActionResult List(BusinessVm input)
        {
            if (input.result==null || input.result.Count==0)
            {
                input.result = businessManager.getAll(null);
            }
            return PartialView(input.result);
        }

        [HttpPost]
        public ActionResult Edit(Guid id, BusinessVo input)
        {

            if (this.ModelState.IsValid)
            {
                var res = businessManager.update(input, id);
                return RedirectToAction("Index");
            }

            return View();

        }
        public ActionResult Edit(Guid id)
        {
            var result = businessManager.get(id);
            return View(result);
        }

        [HttpPost]
        public ActionResult Create(BusinessVo input)
        {

            if (this.ModelState.IsValid)
            {

                var item = businessManager.insert(input);
                return RedirectToAction("Index");
            }


            return View();

        }

        public ActionResult Create()
        {
            var vo = new BusinessVo();
            return View(vo);
        }

        public ActionResult Details(Guid id)
        {
            var result = businessManager.get(id);
            return View(result);
        }

        public ActionResult Menu()
        {
            return PartialView("_Menu");
        }

        

        public ActionResult Delete(Guid id)
        {
            businessManager.delete(id);
            return RedirectToAction("Index");
        }

      
    }
}
