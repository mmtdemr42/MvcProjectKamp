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
    [Authorize(Roles = "A")]
    public class AdminAuthorizedController : Controller
    {
        AdminManager manager = new AdminManager(new EfAdminDal());
        // GET: AdminAuthorized
        public ActionResult Index()
        {
            var admins = manager.List();
            return View(admins);
        }

        public ActionResult AddAdmin()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddAdmin(Admin admin)
        {
            admin.AdminRole = "B";
            manager.Add(admin);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            List<SelectListItem> adminRoles = new List<SelectListItem>() {
                new SelectListItem{Text = "A", Value = "1"},
                new SelectListItem{Text = "B", Value = "2"}
            };
            ViewBag.adminRoles = adminRoles;
            var admin = manager.GetByID(id);
            return View(admin);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Admin admin)
        {
            manager.Update(admin);
            return RedirectToAction("Index");
        }

    }
}