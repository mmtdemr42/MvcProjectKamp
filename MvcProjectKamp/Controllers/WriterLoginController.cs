using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcProjectKamp.Controllers
{
    [AllowAnonymous]
    public class WriterLoginController : Controller
    {
        WriterManager manager = new WriterManager(new EfWriterDal());
        // GET: WriterLogin
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Writer writer)
        {
            var user = manager.Login(writer.WriterEmail, writer.WriterPassword);
            if (user!=null)
            {
                FormsAuthentication.SetAuthCookie(writer.WriterEmail, false);
                Session["WriterEmail"] = writer.WriterEmail;
                return RedirectToAction("../WriterHeading/MyHeadings");
            }
            else
            {
                ViewBag.Error = "Yanlış kullanıcı adı yada şifre";
            }
            return View();
        }

        public ActionResult LogOut()
        {
            manager.LogOut();
            Session.Abandon();
            return RedirectToAction("Headings", "Default");
        }
    }
}