using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.FluentValidation
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(c => c.ContactSubject).NotEmpty().WithMessage("Konu alanı boş geçilemez");
            RuleFor(c => c.ContactSubject).Length(5,50).WithMessage("Konu alanı 5-50 karakterden oluşabilmektedir");
            RuleFor(c => c.UserEmail).NotEmpty().WithMessage("Mail alanı  boş geçilemez");
            RuleFor(c => c.UserEmail).Must(d=>d.Contains("@")).WithMessage("Email alanı doğru bir şekilde giriniz");
            RuleFor(c => c.UserEmail).Must(d=>d.Contains(".com")).WithMessage("Email alanı doğru bir şekilde giriniz");
            RuleFor(c => c.ContactMessage).NotEmpty().WithMessage("Mesaj alanı boş geçilemez");
            RuleFor(c => c.UserName).NotEmpty().WithMessage("İsim alanı boş geçilemez");
            RuleFor(c => c.UserName).Length(5, 50).WithMessage("İsim alanı 5-50 karakterden oluşabilmektedir");
        }
    }
}
