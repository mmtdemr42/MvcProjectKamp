using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectKamp.Controllers
{
    public class AdminAboutController : Controller
    {
        AboutManager manager = new AboutManager(new EfAboutDal());
        // GET: AdminAbout
        public ActionResult Index()
        {
            var about = manager.List();
            return View(about);
        }

        public ActionResult AddAbout()
        {
            return View();
        }


        [HttpPost]
        public ActionResult AddAbout(About about)
        {
            manager.Add(about);
            return RedirectToAction("Index");
        }

        public PartialViewResult AboutAdd()
        {
            return PartialView();
        }
    }
}