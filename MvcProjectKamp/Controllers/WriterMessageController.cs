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
    public class WriterMessageController : Controller
    {
        MessageManager manager = new MessageManager(new EfMessageDal());
        MessageValidator validator = new MessageValidator();
        ValidationResult result;
        // GET: WriterMessage
        public ActionResult Index()
        {
            var message = manager.List();
            ViewBag.StatusMessageFalse = message.Where(m => m.MessageStatus == false).Count() == 0 ? 0 : message.Where(m => m.MessageStatus == false).Count();
            return View(message);
        }

        public PartialViewResult GetMessageMenu()
        {
            var message = manager.List();
            return PartialView(message);
        }

        public ActionResult SenderMessage()
        {
            var message = manager.GetSenderMessage((string)Session["WriterEmail"]);
            return View(message);
        }

        public ActionResult ReceiverMessage()
        {
            var message = manager.GetReceiverMessage((string)Session["WriterEmail"]);
            ViewBag.StatusMessageFalse = manager.List().Where(m => m.MessageStatus == false).Count() ==0  ? 0 : message.Where(m => m.MessageStatus == false).Count();
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
                message.SenderMail= (string)Session["WriterEmail"];
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
            message.MessageStatus = true;
            manager.Update(message);
            return View(message);
        }
    }
}