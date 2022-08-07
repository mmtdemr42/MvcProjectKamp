using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.FluentValidation
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(w => w.WriterName).NotEmpty().WithMessage("İsim alanı boş geçilemez!");
            RuleFor(w => w.WriterName).MinimumLength(3).WithMessage("İsim alanı en az 3 karakterden oluşabilir!");
            RuleFor(w => w.WriterName).MaximumLength(20).WithMessage("İsim alanı en fazla 20 karakterden oluşabilir!");
            RuleFor(w => w.WriterSurname).NotEmpty().WithMessage("Soyisim alanı boş geçilemez!");
            RuleFor(w => w.WriterSurname).MinimumLength(3).WithMessage("Soyisim alanı en az 3 karakterden oluşabilir!");
            RuleFor(w => w.WriterSurname).MaximumLength(20).WithMessage("Soyisim alanı en fazla 20 karakterden oluşabilir!");
            RuleFor(w => w.WriterEmail).NotEmpty().WithMessage("Email alanı boş geçilemez!");
            RuleFor(w => w.WriterEmail).MaximumLength(20).WithMessage("Email alanı en fazla 20 karakterden oluşabilir!");
            RuleFor(w => w.WriterAbout).Must(w => w != null && w.ToUpper().Contains("A")).WithMessage("Hakkımızda bölümünde en az bir tane A harfi bulunması gerekmektedir.");
            RuleFor(w => w.WriterName).NotEmpty().WithMessage("İsim alanı boş geçilemez!");
            RuleFor(w => w.WriterPassword).NotEmpty().WithMessage("Parola alanı boş geçilemez!");
            RuleFor(w => w.WriterPassword).Length(8, 20).WithMessage("Parola uzunluğu 8-20 karakter arasında olması gerekmektedir.");
            RuleFor(w => w.WriterTitle).NotEmpty().WithMessage("Unvan alanı boş geçilemez!");
            RuleFor(w => w.WriterTitle).Length(8, 20).WithMessage("Unvan uzunluğu 8-20 karakter arasında olması gerekmektedir.");
        }
    }
}
