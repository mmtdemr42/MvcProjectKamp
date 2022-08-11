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
        // GET: WriterContent
        public ActionResult ContentByWriterHeadings(int id)
        {
            var headings = manager.GetByWriterID(1003);
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