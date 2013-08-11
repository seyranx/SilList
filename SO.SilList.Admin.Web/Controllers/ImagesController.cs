using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SO.SilList.Manager.Managers;

namespace SO.SilList.Admin.Web.Controllers
{
    public class ImagesController : Controller
    {
        private ImageManager imageManager = new ImageManager();

        //
        // GET: /Image/

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult List()
        {
            var results = imageManager.getAll(null);
            return PartialView(results);
        }

    }
}
