using SO.SilList.Manager.Managers;
using SO.SilList.Manager.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SO.SilList.Admin.Web.Controllers
{
    public class RentalController : Controller
    {
        //
        // GET: /Rentals/

        private RentalManager rentalManager = new RentalManager();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            var results = rentalManager.getAll(null);
            return PartialView("_List",results);
        }

        [HttpPost]
        public ActionResult Edit(Guid id, RentalVo input)
        {
            if (this.ModelState.IsValid)
            {
                var result = rentalManager.update(input, id);
                    return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(Guid id)
        {
            var result = rentalManager.get(id);
                return View(result);
        }

        [HttpPost]
        public ActionResult Create(RentalVo input)
        {
            if(this.ModelState.IsValid)
            {
                var rentalItem = rentalManager.insert(input);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Create()
        {
            var vo = new RentalVo();
            return View(vo);
        }

        public ActionResult Details(Guid id)
        {
            var result = rentalManager.get(id);
            return View(result);
        }

        public ActionResult Menu()
        {
            return PartialView("../Rental/_Menu");
        }

        public ActionResult Delete(Guid id)
        {
            rentalManager.delete(id);
            return RedirectToAction("index");
        }
    }
}
