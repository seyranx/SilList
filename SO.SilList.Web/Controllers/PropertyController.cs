using SO.SilList.Manager.Managers;
using SO.SilList.Manager.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SO.SilList.Web.Controllers
{
    public class PropertyController : Controller
    {
        private PropertyManager propertyManager = new PropertyManager();

        //
        // GET: /Property/
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Create new Property 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(PropertyVo input)
        {
            ViewBag.Title = "Add New Property";

            if (this.ModelState.IsValid)
            {
                var item = propertyManager.insert(input);
                
                return RedirectToAction("Index");
            }

            return View(input);
        }
        
        public ActionResult Create()
        {
            var vo = new PropertyVo();
            return View(vo);
        }

	}
}