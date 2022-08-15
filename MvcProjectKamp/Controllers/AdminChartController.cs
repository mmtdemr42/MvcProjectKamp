using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using MvcProjectKamp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectKamp.Controllers
{
    public class AdminChartController : Controller
    {
        HeadingManager manager = new HeadingManager(new EfHeadingDal());
        ContentManager contentManager = new ContentManager(new EfContectDal());
        // GET: AdminChart
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CategoryCountChart()
        {
            List<CategoryHeadingCount> categoryHeadings = new List<CategoryHeadingCount>();
            categoryHeadings = manager.List().GroupBy(a => a.Category).Select(h=> new CategoryHeadingCount { CategoryName = h.Key.CategoryName, CategoryCount= h.Key.Headings.Count()}).ToList();
            return Json(categoryHeadings, JsonRequestBehavior.AllowGet);
        }

        public ActionResult HeadingCount()
        {
            List<HeadingContentCount> counts = new List<HeadingContentCount>();
            counts = contentManager.List().GroupBy(a=>a.Heading).Select(c => new HeadingContentCount { HeadingName = c.Key.HeadingName, ContentCount=c.Key.Contents.Count()}).ToList();
            return Json(counts, JsonRequestBehavior.AllowGet);
        }

        public ActionResult HeadingContent()
        {
            return View();
        }
        public ActionResult HeadingDate()
        {
            List<HeadingDateCount> headings = new List<HeadingDateCount>();
            headings = manager.List().GroupBy(a=>a.HeadingDate.Day).Select(b => new HeadingDateCount { HeadingDate = b.Key.ToString(), HeadingCount = b.Count() }).ToList();
            return Json(headings, JsonRequestBehavior.AllowGet);

        }

        public ActionResult LineChart()
        {
            return View();
        }
    }
}
