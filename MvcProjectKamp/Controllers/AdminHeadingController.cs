using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
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
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        WriterManager writerManager = new WriterManager(new EfWriterDal());
        ValidationResult result;
        // GET: AdminHeading
        public ActionResult Index()
        {
            return View(manager.List());
        }

        public ActionResult AddHeading()
        {
            List<SelectListItem> valueCategory = (from category in categoryManager.List()
                                                  select new SelectListItem
                                                  {
                                                      Text = category.CategoryName,
                                                      Value = category.CategoryID.ToString(),
                                                  }).ToList();

            List<SelectListItem> valueWriter = (from writer in writerManager.List()
                                                select new SelectListItem
                                                {
                                                    Text = writer.WriterName + " " + writer.WriterSurname,
                                                    Value = writer.WriterID.ToString(),
                                                }).ToList();
            ViewBag.valueCategory = valueCategory;
            ViewBag.valueWriter = valueWriter;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddHeading(Heading heading)
        {
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortTimeString());
            manager.Add(heading);
            return RedirectToAction("Index");
        }


        public ActionResult Edit(int id)
        {
            List<SelectListItem> valueCategory = (from category in categoryManager.List()
                                                  select new SelectListItem
                                                  {
                                                      Text = category.CategoryName,
                                                      Value = category.CategoryID.ToString(),
                                                  }).ToList();
            List<SelectListItem> valueWriter = (from writer in writerManager.List()
                                                select new SelectListItem
                                                {
                                                    Text = writer.WriterName + " " + writer.WriterSurname,
                                                    Value = writer.WriterID.ToString(),
                                                }).ToList();
            ViewBag.valueCategory = valueCategory;
            ViewBag.valueWriter = valueWriter;
            var heading = manager.GetByID(id);
            return View(heading);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Heading heading)
        {
            heading.HeadingDate = DateTime.Now;
            manager.Update(heading);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var heading = manager.GetByID(id);
            heading.HeadingStatus = !heading.HeadingStatus;
            manager.Update(heading);
            return RedirectToAction("Index");
        }
    }
}