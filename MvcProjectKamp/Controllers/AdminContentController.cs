using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectKamp.Controllers
{
    public class AdminContentController : Controller
    {
        ContentManager manager = new ContentManager(new EfContectDal());
        // GET: AdminContent
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ContentByHeading(int id)
        {
            var content = manager.GetByHeadingID(id);
            return View(content);
        }
    }
}