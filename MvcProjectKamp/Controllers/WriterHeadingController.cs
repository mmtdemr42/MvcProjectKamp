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
    public class WriterHeadingController : Controller
    {
        HeadingManager manager = new HeadingManager(new EfHeadingDal());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        // GET: WriterHeading
        public ActionResult MyHeadings()
        {
            var headings = manager.GetByHeadings(1).Where(h=>h.HeadingStatus==true);
            return View(headings);
        }

        public ActionResult NewHeading()
        {
            List<SelectListItem> valueCategory = (from category in categoryManager.List()
                                                  select new SelectListItem
                                                  {
                                                      Text = category.CategoryName,
                                                      Value = category.CategoryID.ToString(),
                                                  }).ToList();
            ViewBag.valueCategory = valueCategory;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewHeading(Heading heading)
        {
            heading.WriterID = 1;
            heading.HeadingDate = DateTime.Now;
            manager.Add(heading);
            return RedirectToAction("MyHeadings");
        }


        public ActionResult Edit(int id)
        {
            List<SelectListItem> valueCategory = (from category in categoryManager.List()
                                                  select new SelectListItem
                                                  {
                                                      Text = category.CategoryName,
                                                      Value = category.CategoryID.ToString(),
                                                  }).ToList();
            ViewBag.valueCategory = valueCategory;
            var heading = manager.GetByID(id);
            return View(heading);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Heading heading)
        {
            manager.Update(heading);
            return RedirectToAction("MyHeadings");
        }

        public ActionResult Delete(int id)
        {
            var heading = manager.GetByID(id);
            heading.HeadingStatus = false;
            manager.Update(heading);
            return RedirectToAction("MyHeadings");
        }
    }
}