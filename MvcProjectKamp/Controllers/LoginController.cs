using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcProjectKamp.Controllers
{
    public class LoginController : Controller
    {
        AdminManager manager = new AdminManager(new EfAdminDal());
        // GET: Login

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin admin)
        {
            var Admin = manager.Login(admin.AdminName, admin.AdminPassword);
            if (Admin != null)
            {
                FormsAuthentication.SetAuthCookie(admin.AdminName, false);
                Session["AdminName"] = admin.AdminName;
                return RedirectToAction("../AdminCategory");
            }
            else
            {
                ViewBag.Error = "Yanlış parola ya da kullanıcı adı";
            }
            return View();
        }
    }
}