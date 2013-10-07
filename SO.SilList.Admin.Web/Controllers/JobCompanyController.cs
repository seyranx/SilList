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
    public class JobCompanyController : Controller
    {
        private JobCompanyManager jobCompanyManager = new JobCompanyManager();
        //
        // GET: /JobCompany/

        public ActionResult Index(JobCompanyVm input = null, Paging paging = null)
        {
            if (input == null) input = new JobCompanyVm();
            input.paging = paging;
            if (this.ModelState.IsValid)
            {
                if (input.submitButton != null)
                    input.paging.pageNumber = 1;
                input = jobCompanyManager.search(input);
                return View(input);
            }
            return View();
        }

        public ActionResult Menu()
        {
            return PartialView("../Job/Menu");
        }
        public ActionResult List()
        {
            var results = jobCompanyManager.getAll(null);
            return PartialView(results);
        }
        [HttpPost]
        public ActionResult Create(JobCompanyVo input)
        {

            if (this.ModelState.IsValid)
            {

                var item = jobCompanyManager.insert(input);
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
        public ActionResult Edit(Guid id, JobCompanyVo input)
        {

            if (this.ModelState.IsValid)
            {
                var res = jobCompanyManager.update(input, id);
                return RedirectToAction("Index");
            }

            return View();
        }
        public ActionResult Details(Guid id)
        {
            var result = jobCompanyManager.get(id);
            return View(result);
        }
        public ActionResult Delete(Guid id)
        {
            jobCompanyManager.delete(id);
            return RedirectToAction("Index");
        }
        public ActionResult Filter(JobCompanyVm Input)
        {
            return PartialView("_Filter", Input);
        }
        public ActionResult Pagination(Paging input)
        {
            return PartialView("_Pagination", input);
        }
    }
}
