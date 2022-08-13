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
    public class WriterContentController : Controller
    {
        ContentManager manager = new ContentManager(new EfContectDal());
        WriterManager writerManager = new WriterManager(new EfWriterDal());
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        int writerId;
        // GET: WriterContent
        public ActionResult ContentByWriterHeadings()
        {
            writerId = writerManager.GetWriter((string)Session["WriterEmail"]);
            var headings= manager.GetByWriterContent(writerId);
            if (headings.Count() !=0)
            {
                ViewBag.Name = headings.FirstOrDefault().Writer.WriterName;
                ViewBag.Surname = headings.FirstOrDefault().Writer.WriterSurname;

            }
            return View(headings);
        }

        public ActionResult ContentByHeadings(int id)
        {
            var headings = manager.GetByHeadingID(id);
            if (headings.Count() != 0)
            {
                ViewBag.Heading = headings.FirstOrDefault().Heading.HeadingName;
            }
            return View(headings);
        }

        public ActionResult NewContent()
        {
            List<SelectListItem> valueHeading = (from heading in headingManager.List()
                                                  select new SelectListItem
                                                  {
                                                      Text = heading.HeadingName,
                                                      Value = heading.HeadingID.ToString(),
                                                  }).ToList();
            ViewBag.valueHeading = valueHeading;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewContent(Content content)
        {
            writerId = writerManager.GetWriter((string)Session["WriterEmail"]);
            content.WriterID = writerId;
            content.ContentDate = DateTime.Now;
            content.ContentStatus = true;
            manager.Add(content);
            return RedirectToAction("ContentByWriterHeadings");

        }

    }
}