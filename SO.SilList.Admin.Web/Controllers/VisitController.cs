using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SO.SilList.Manager.Interfaces;
using SO.SilList.Manager.Models.ViewModels;
using SO.SilList.Manager.Managers;

namespace SO.SilList.Admin.Web.Controllers
{
    public class VisitController : Controller
    {
        private IVisitManager visitManager = new VisitManager(); 

        public ActionResult Index(VisitVm input = null)
        {
            if (null == input) 
                input = new VisitVm();

            if (this.ModelState.IsValid)
            {
                input.result = visitManager.search(input);
                input.totalRows = visitManager.count(input);
                return View(input);
            }

            return View();
        }

        public ActionResult Filter(VisitVm input)
        {
            return PartialView("_Filter", input);
        }

        public ActionResult Pagination(VisitVm input)
        {
            return PartialView("_Pagination");
        }

        public ActionResult Menu()
        {
            return PartialView("../Admin/_Menu");
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
