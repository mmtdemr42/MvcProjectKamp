using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectKamp.Controllers
{
    public class AdminHeadingController : Controller
    {
        HeadingManager manager = new HeadingManager(new EfHeadingDal());
        // GET: AdminHeading
        public ActionResult Index()
        {
            return View(manager.List());
        }
    }
}