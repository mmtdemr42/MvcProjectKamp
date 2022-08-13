using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace MvcProjectKamp.Controllers
{
    public class WriterHeadingController : Controller
    {
        HeadingManager manager = new HeadingManager(new EfHeadingDal());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        WriterManager writerManager = new WriterManager(new EfWriterDal());
        int writerId;
        // GET: WriterHeading

        public ActionResult MyHeadings()
        {
            writerId = writerManager.GetWriter((string)Session["WriterEmail"]);
            ViewBag.T = writerId;
            var headings = manager.GetByHeadingsTrue(writerId);
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
            writerId = writerManager.GetWriter((string)Session["WriterEmail"]);
            heading.WriterID = writerId;
            heading.HeadingStatus = true;
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

        public ActionResult AllHeadings(int page = 1)
        {
            for (int i = 1; i < manager.List().Count() / 4; i++)
            {

                if (page == 1)
                {
                    ViewBag.desk = page;

                }
                else
                {
                    ViewBag.desk = page + 4;
                }
            }
            var headings = manager.List().ToPagedList(page, 5);
            return View(headings);
        }
    }
}