using SO.SilList.Manager.Managers;
using SO.SilList.Manager.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SO.SilList.Admin.Web.Controllers
{
    public class RentalsController : Controller
    {
        //
        // GET: /Rentals/

        private RentalsManager rentalManager = new RentalsManager();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult _List()
        {
            var results = rentalManager.getAll(null);
            return PartialView(results);
        }

        [HttpPost]
        public ActionResult Edit(Guid id, RentalsVo input)
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
        public ActionResult Create(RentalsVo input)
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
            return View();
        }

        public ActionResult Details(Guid id)
        {
            var result = rentalManager.get(id);
            return View(result);
        }

        public ActionResult Menu()
        {
            return PartialView("../Rentals/_Menu");
        }

        public ActionResult Delete(Guid id)
        {
            rentalManager.delete(id);
            return RedirectToAction("index");
        }
    }
}
