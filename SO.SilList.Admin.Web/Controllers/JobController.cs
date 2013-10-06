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
    public class JobController : Controller
    {

        private JobManager jobManager = new JobManager ();
        //
        // GET: /Rentals/

        public ActionResult Index(JobVm input = null, Paging paging = null)
        {
            if (input == null) input = new JobVm();
            input.paging = paging;
            if (this.ModelState.IsValid)
            {
                if (input.submitButton != null)
                    input.paging.pageNumber = 1;
                input = jobManager.search(input);
                return View(input);
            }
            return View();
        }

        public ActionResult Menu()
        {
            return PartialView("_Menu");
        }
        public ActionResult List()
        {
            var results = jobManager.getAll(null);
            return PartialView(results);
        }
        [HttpPost]
        public ActionResult Create(JobVo input)
        {

            if (this.ModelState.IsValid)
            {

                var item = jobManager.insert(input);
                return RedirectToAction("Index");
            }


            return View();
        }
             public ActionResult Create()
        {
            return View();
        }
        public ActionResult Edit()
        {
            return View();
        }
           [HttpPost]
        public ActionResult Edit(Guid id, JobVo input)
        {

            if (this.ModelState.IsValid)
            {
                var res = jobManager.update(input, id);
                return RedirectToAction("Index");
            }

            return View();
        }
           public ActionResult Details(Guid id)
           {
               var result = jobManager.get(id);
               return View(result);
           }
           public ActionResult Delete(Guid id)
           {
               jobManager.delete(id);
               return RedirectToAction("Index");
           }
           public ActionResult Filter(JobVm Input)
           {
               return PartialView("_Filter", Input);
           }
           public ActionResult Pagination(Paging input)
           {
               return PartialView("_Pagination", input);
           }
    }
}
