using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SO.SilList.Manager.Managers;
using SO.SilList.Manager.Models.ValueObjects;
using SO.SilList.Manager.Models.ViewModels;
using SO.SilList.Utility.Classes;

namespace SO.SilList.Admin.Web.Controllers
{
    public class ServiceTypeController : Controller
    {
        private ServiceTypeManager serviceTypeManager = new ServiceTypeManager();

        //
        // GET: /ServiceType/

        public ActionResult Index(ServiceTypeVm input = null,Paging paging = null)
        {
            if (input == null)
                input = new ServiceTypeVm();
            input.paging = paging;
            if (this.ModelState.IsValid)
            {
                if (input.submitButton != null)
                    input.paging.pageNumber = 1;
                input = serviceTypeManager.search(input);
                return View(input);
            }
            return View();
        }

        public ActionResult Filter(ServiceTypeVm Input)
        {
            return PartialView("_Filter", Input);
        }

        public ActionResult List()
        {
            var results = serviceTypeManager.getAll(null);
            return PartialView(results);
        }


        public ActionResult Menu()
        {
            return PartialView("../Business/_Menu");
        }

        [HttpPost]
        public ActionResult Create(ServiceTypeVo input)
        {

            if (this.ModelState.IsValid)
            {

                var item = serviceTypeManager.insert(input);
                return RedirectToAction("Index");
            }


            return View();

        }

        public ActionResult Create()
        {
            var vo = new ServiceTypeVo();
            return View(vo);
        }

        [HttpPost]
        public ActionResult Edit(int id, ServiceTypeVo input)
        {

            if (this.ModelState.IsValid)
            {
                var res = serviceTypeManager.update(input, id);
                return RedirectToAction("Index");
            }

            return View();

        }
        public ActionResult Edit(int id)
        {
            var result = serviceTypeManager.get(id);
            return View(result);
        }

        public ActionResult Details(int id)
        {
            var result = serviceTypeManager.get(id);
            return View(result);
        }

        public ActionResult Pagination(Paging input)
        {
            return PartialView("_Pagination", input);
        }
        
        public ActionResult Delete(int id)
        {
            serviceTypeManager.delete(id);
            return RedirectToAction("Index");
        }

    }
}
