using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectKamp.Controllers
{
    public class DefaultController : Controller
    {
        HeadingManager manager = new HeadingManager(new EfHeadingDal());
        ContentManager contentManager = new ContentManager(new EfContectDal());
        // GET: Default
        public PartialViewResult Index(int id=0)
        {
            var contents = contentManager.GetByHeadingID(id);
            ViewBag.Heading = contents.Select(a => a.Heading.HeadingName).FirstOrDefault();
            return PartialView(contents);
        }

        public ActionResult Headings()
        {
            var headings = manager.List();
            return View(headings);
        }

    }
}