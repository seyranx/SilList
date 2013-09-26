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
    public class TransmissionTypeController : Controller
    {
        private TransmissionTypeManager transmissionTypeManager = new TransmissionTypeManager();
        //
        // GET: /TransmissionType/

        public ActionResult Index(TransmissionTypeVm input = null,Paging paging = null)
        {
            if (input == null) input = new TransmissionTypeVm();
            input.paging = paging;
            if (this.ModelState.IsValid)
            {
                if (input.submitButton != null)
                    input.paging.pageNumber = 1;
                input = transmissionTypeManager.search(input);
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
            var results = transmissionTypeManager.getAll(null);
            return PartialView(results);
        }

        [HttpPost]
        public ActionResult Create(TransmissionTypeVo input)
        {

            if (this.ModelState.IsValid)
            {

                var item = transmissionTypeManager.insert(input);
                return RedirectToAction("Index");
            }


            return View();

        }

        public ActionResult Create()
        {
            var vo = new TransmissionTypeVo();
            return View(vo);
        }

        [HttpPost]
        public ActionResult Edit(int id, TransmissionTypeVo input)
        {

            if (this.ModelState.IsValid)
            {
                var res = transmissionTypeManager.update(input, id);
                return RedirectToAction("Index");
            }

            return View();

        }
        public ActionResult Edit(int id)
        {
            var result = transmissionTypeManager.get(id);
            return View(result);
        }

        public ActionResult Details(int id)
        {
            var result = transmissionTypeManager.get(id);
            return View(result);
        }

        public ActionResult Delete(int id)
        {
            transmissionTypeManager.delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult DropDownList(int? id = null)
        {
            ViewBag.transmissions = transmissionTypeManager.getAll(null);
            var transmission = new TransmissionTypeVo();
            if (id != null)
            {
                transmission = transmissionTypeManager.get(id.Value);
            }
            return PartialView("_DropDownList", transmission);
        }

        public ActionResult Pagination(Paging input)
        {
            return PartialView("_Pagination",input);
        }

        public ActionResult Filter(TransmissionTypeVm input)
        {
            return PartialView("_Filter", input);
        }

    }
}
