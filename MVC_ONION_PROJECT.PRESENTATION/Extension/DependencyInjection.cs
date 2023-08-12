using AspNetCoreHero.ToastNotification;
using FluentValidation;
using FluentValidation.AspNetCore;
using System.Reflection;

namespace MVC_ONION_PROJECT.PRESENTATION.Extension
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentationService(this IServiceCollection services)
        {

            services.AddControllersWithViews(opt=>opt.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes=true);
            //her türlü null izni veriyor, tek tek VM lere ? yazmak yerine bunu kullan

            services.AddFluentValidationAutoValidation().AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddNotyf(config =>
            {
                config.HasRippleEffect = true;
                config.Position = NotyfPosition.BottomRight;
                config.IsDismissable = true;
                config.DurationInSeconds = 5;
            });
            return services;
        }
    }
}
