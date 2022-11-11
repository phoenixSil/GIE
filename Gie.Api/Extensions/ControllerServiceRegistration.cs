using Gie.Api.Services.Contrats;
using Gie.Api.Services;

namespace Gie.Api.Extensions
{
    public static class ControllerServiceRegistration
    {
        public static IServiceCollection ConfigureControllerServices(this IServiceCollection services)
        {
            services.AddScoped<IServiceDadresse, ServiceDadresse>();
            services.AddScoped<IServiceDetudiant, ServiceDetudiant>();
            services.AddScoped<IServiceDeNiveau, ServiceDeNiveau>();

            return services;
        }
    }
}
