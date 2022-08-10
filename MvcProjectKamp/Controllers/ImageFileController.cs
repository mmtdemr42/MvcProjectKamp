using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectKamp.Controllers
{
    public class ImageFileController : Controller
    {
        ImageFileManager manager = new ImageFileManager(new EfImageFileDal());
        // GET: ImageFile
        public ActionResult Index()
        {
            var images = manager.List();
            return View(images);
        }
    }
}