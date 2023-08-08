using FluentValidation;
using MVC_ONION_PROJECT.PRESENTATION.Models.AuthorVMs;

namespace MVC_ONION_PROJECT.PRESENTATION.FluentValidators.AuthorValidators
{
    public class AuthorCreateValidator : AbstractValidator<AuthorCreateVM>
    {
        public AuthorCreateValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Yazar İsmi Zorunludur.").NotNull().WithMessage("Yazar İsmi Zorunludur").MinimumLength(3).WithMessage("Yazar İsmi En az 3 karakter olmalı");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Yazar soyismi Zorunludur.").NotNull().WithMessage("Yazar soyismi Zorunludur").MinimumLength(3).WithMessage("Yazar soyismi En az 3 karakter olmalı");
            RuleFor(x => x.DateofBirth).LessThan(DateTime.Now).WithMessage("İleri tarih seçilemez").Must(AgeControl).WithMessage("Yazar 18 yaşından küçük olamaz.");
        }


        private bool AgeControl(DateTime date)
        {
            int value = date.Year;
            int nowValue = DateTime.Now.Year;


            if (nowValue - value >= 18)
            {
                return true;
            }

            else { return false; }


        }


    }
}
