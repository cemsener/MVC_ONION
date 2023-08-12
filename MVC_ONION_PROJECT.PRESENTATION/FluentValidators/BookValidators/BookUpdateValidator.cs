using FluentValidation;
using MVC_ONION_PROJECT.PRESENTATION.Models.BookVMs;

namespace MVC_ONION_PROJECT.PRESENTATION.FluentValidators.BookValidators
{
    public class BookUpdateValidator : AbstractValidator<BookUpdateVM>
    {
        public BookUpdateValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Kitap İsmi Zorunludur.").NotNull().WithMessage("Kitap İsmi Zorunludur").MinimumLength(3).WithMessage("Kitap İsmi En az 3 karakter olmalı");
            RuleFor(x => x.PublicationDate).LessThan(DateTime.Now).WithMessage("İleri tarih seçilemez");
        }
    }
}
