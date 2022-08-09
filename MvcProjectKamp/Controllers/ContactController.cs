using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectKamp.Controllers
{
    public class ContactController : Controller
    {
        ContactManager manager = new ContactManager(new EfContactDal());
        // GET: Contact
        public ActionResult Index()
        {
            var contact = manager.ListOrderByDescending();
            return View(contact);
        }

        public ActionResult GetByMessage(int id)
        {
            var message = manager.GetByID(id);
            return View(message);
        }

        public PartialViewResult GetMessageMenu()
        {
            var contact = manager.List();

            return PartialView(contact);
        }
    }
}