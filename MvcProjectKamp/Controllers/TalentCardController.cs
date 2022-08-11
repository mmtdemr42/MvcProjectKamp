using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectKamp.Controllers
{
    public class TalentCardController : Controller
    {
        TalentManager manager = new TalentManager(new EfTalentDal());
        // GET: TalentCard
        public ActionResult Index()
        {
            var talents = manager.List();
            return View(talents);
        }
    }
}