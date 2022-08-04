using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.FluentValidation
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(c => c.CategoryName).NotEmpty().WithMessage("Kategori adı boş geçilemez");
            RuleFor(c => c.CategoryDescription).NotEmpty().WithMessage("Kategori açıklaması boş geçilemez");
            RuleFor(c => c.CategoryName).MinimumLength(3).WithMessage("Kategori adı en az 3 karakterden oluşması gerekmektedir");
            RuleFor(c => c.CategoryName).MaximumLength(20).WithMessage("Kategori adı en fazla 20 karakterden oluşması gerekmektedir");
        }
    }
}
