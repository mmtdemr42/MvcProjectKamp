using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.FluentValidation
{
    public class MessageValidator : AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(m => m.MessageContent).NotEmpty().WithMessage("Mesaj içeriği boş olamaz.");
            RuleFor(m => m.MessageContent).MinimumLength(20).WithMessage("Mesaj içeriği en az 20 karakter olması gerekmektedir");
            RuleFor(m => m.MessageSubject).Length(5,50).WithMessage("Mesaj başlığı 5-50 arasında karakter olması gerekmektedir");
            RuleFor(m => m.MessageSubject).NotEmpty().WithMessage("Mesaj başlığı boş olamaz.");
            RuleFor(m => m.ReceiverMail).NotEmpty().WithMessage("Alıcı adresi boş olamaz.");
        }
    }
}
