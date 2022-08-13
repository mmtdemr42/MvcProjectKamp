using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules.FluentValidation;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectKamp.Controllers
{
    public class WriterController : Controller
    {
        WriterManager manager = new WriterManager(new EfWriterDal());
        WriterValidator validator = new WriterValidator();
        ValidationResult result;
        int writerId;
        // GET: Writer
        public ActionResult Index()
        {
            writerId = manager.GetWriter((string)Session["WriterEmail"]);
            var writer = manager.GetByID(writerId);
            return View(writer);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Writer writer)
        {
            result = validator.Validate(writer);
            if (result.IsValid)
            {
                manager.Update(writer);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
            }
            return View(writer);
        }

    }
}