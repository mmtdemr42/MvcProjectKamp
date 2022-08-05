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
    public class AdminWriterController : Controller
    {
        WriterManager manager = new WriterManager(new EfWriterDal());
        WriterValidator writerValidator = new WriterValidator();
        ValidationResult result;
        // GET: AdminWriter
        public ActionResult Index()
        {
            return View(manager.Get());
        }

        public ActionResult AddWriter()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddWriter(Writer writer)
        {

            result = writerValidator.Validate(writer);

            if (result.IsValid)
            {
                manager.Add(writer);
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