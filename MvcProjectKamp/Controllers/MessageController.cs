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
    public class MessageController : Controller
    {
        MessageManager manager = new MessageManager(new EfMessageDal());
        MessageValidator validator = new MessageValidator();
        ValidationResult result;
        // GET: Message
        public ActionResult Index()
        {
            var message = manager.List();
            return View(message);
        }

        public ActionResult SenderMessage()
        {
            var message = manager.GetSenderMessage();
            return View(message);
        }

        public ActionResult ReceiverMessage()
        {
            var message = manager.GetReceiverMessage();
            return View(message);
        }

        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult NewMessage(Message message)
        {

            message.MessageDate = DateTime.Now;
            result = validator.Validate(message);
            if (result.IsValid)
            {
                manager.Add(message);
                return RedirectToAction("SenderMessage");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
            }
            return View(message);
        }

        public ActionResult GetByMessage(int id)
        {
            var message = manager.GetByID(id);
            return View(message);
        }
    }
}