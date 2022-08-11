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
    public class DraftController : Controller
    {
        DraftManager manager = new DraftManager(new EfDraftDal());
        // GET: Draft
        public ActionResult Index()
        {
            var drafts = manager.List();
            return View(drafts);
        }

        public ActionResult GetByMessage(int id)
        {
            var draft = manager.GetByID(id);
            return View(draft);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewDraft(Draft draft)
        {
            draft.DraftDate = DateTime.Now;
            manager.Add(draft);
            return RedirectToAction("Index");
        }
    }
}