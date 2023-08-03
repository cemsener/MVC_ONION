using System.Reflection;

namespace MVC_ONION_PROJECT.PRESENTATION.Extension
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentationService(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
