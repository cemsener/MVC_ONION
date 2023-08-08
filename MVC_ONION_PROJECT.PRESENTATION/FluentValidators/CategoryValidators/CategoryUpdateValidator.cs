using FluentValidation;
using MVC_ONION_PROJECT.PRESENTATION.Models.CategoryVMs;

namespace MVC_ONION_PROJECT.PRESENTATION.FluentValidators.CategoryValidators
{
    public class CategoryUpdateValidator : AbstractValidator<CategoryUpdateVM>
    {
        public CategoryUpdateValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("Kategori İsmi Boş Geçilemez").NotEmpty().WithMessage("Kategori İsmi Boş Geçilemez").MinimumLength(5).WithMessage("Kategori Adı En Az 5 Karakterli Olmalıdır");

            RuleFor(x => x.Description).NotNull().WithMessage("Açıklama Boş Geçilemez").NotEmpty().WithMessage("Açıklama Boş Geçilemez").MinimumLength(15).WithMessage("Açıklama En Az 15 Karakterli Olmalıdır");
        }

    }
}
