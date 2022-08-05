using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectKamp.Controllers
{
    public class IstatistikController : Controller
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        // GET: Istatistik
        public ActionResult Index()
        {
            ViewBag.HeadingCount = headingManager.CategoryHeadingCount(1);
            ViewBag.CategoryCount = categoryManager.CategoryCount();
            ViewBag.HeadingA = headingManager.HeadingFilter("a".ToUpper());
            ViewBag.MaxCategoryName = categoryManager.MaxCategoryHeading().CategoryName;
            ViewBag.StatusDiffrence = categoryManager.StatusDifference();
            return View();
        }
    }
}