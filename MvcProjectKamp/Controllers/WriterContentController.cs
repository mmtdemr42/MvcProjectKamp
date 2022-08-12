using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
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
    }
}