using FluentValidation;
using SadakaEli.Model.ComplexTypes.Yonetim.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SadakaEli.Business.ValidationRules.FluentValidation
{
    public class NewAdminValidator : AbstractValidator<NewAdminVm>
    {
        public NewAdminValidator()
        {
            RuleFor(x => x.FullName)
                .NotEmpty()
                .WithMessage("Ad Soyad Boş Bırakılamaz.")
                .MinimumLength(3)
                .WithMessage("Ad Soyad En Az 3 Karakterli Olmalıdır.");
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("E-Mail Boş Bırakılamaz")
                .EmailAddress()
                .WithMessage("E-Mailiniz Geçerli Bir Formatta Değilidir.");
            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Şifre boş bırakılamaz")
                .MinimumLength(5)
                .WithMessage("Şifre en az 5 karakter olmalşıdır")
                .Must(IsPasswordValid)
                .WithMessage("Şifrede en az 1 rakam en az 1 küçük harf olmalıdır");

            RuleFor(x => x.RePassword)
               .NotEmpty()
               .WithMessage("Şifre boş bırakılamaz")
               .MinimumLength(5)
               .WithMessage("Şifre en az 5 karakter olmalşıdır")
               .Equal(x => x.Password)
               .WithMessage("Şifre ile tekrarı aynı olmalıdır");


        }

        private bool IsPasswordValid(string password)
        {
            password = password != null ? password : "";

            string lower = "abcdefghijklmnoprstuvyz";
            string digits = "0123456789";

            bool isValidForLower = false;
            bool isValidForDigit = false;

            for (int i = 0; i < password.Length; i++)
            {
                if (lower.Contains(password[i]))
                {
                    isValidForLower = true;
                }

                if (digits.Contains(password[i]))
                {
                    isValidForDigit = true;
                }

            }

            if (isValidForLower && isValidForDigit)
                return true;

            return false;


        }
    }
}
