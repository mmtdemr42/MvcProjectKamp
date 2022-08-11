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
    public class AdminCategoryController : Controller
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        CategoryValidator categoryValidator = new CategoryValidator();
        // GET: AdminCategory
        [Authorize(Roles ="A")]
        public ActionResult Index()
        {
            return View(categoryManager.List());
        }

        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddCategory(Category category)
        {
            ValidationResult results = categoryValidator.Validate(category);

            if (results.IsValid)
            {
                categoryManager.Add(category);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var error in results.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
            }

            return View(category);
        }

        public ActionResult Delete(int id)
        {
            var category = categoryManager.GetByID(id);
            categoryManager.Delete(category);
            return RedirectToAction("Index");

        }

        public ActionResult Edit(int id)
        {
            var category = categoryManager.GetByID(id);
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category category)
        {
            ValidationResult results = categoryValidator.Validate(category);

            if (results.IsValid)
            {
                categoryManager.Update(category);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var error in results.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
            }
            return RedirectToAction("Index");
        }
    }
}