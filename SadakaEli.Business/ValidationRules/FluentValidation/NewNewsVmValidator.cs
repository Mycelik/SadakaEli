using FluentValidation;
using SadakaEli.Model.ComplexTypes.Yonetim.News;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SadakaEli.Business.ValidationRules.FluentValidation
{
    public class NewNewsVmValidator : AbstractValidator<NewNewsVm>
    {
        public NewNewsVmValidator()
        {
            RuleFor(x => x.Headline)
                .NotEmpty()
                .WithMessage("Haberin Başlığı Boş Bırakılamaz.")
                .MinimumLength(5)
                .WithMessage("Haberin Başlığı En Az 5 Karakterli Olmalıdır.");
            RuleFor(x => x.Explanation)
                .NotEmpty()
                .WithMessage("Haberin İçeriği Boş Bırakılamaz")
                .MinimumLength(30)
                .WithMessage("Haberin İçeriği En Az 30 Karakterli Olmalıdır.");


        }
    }
}
