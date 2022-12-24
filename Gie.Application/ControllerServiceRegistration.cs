using Gie.Features.Contrats.Services;
using Gie.Features.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Gie.Application
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
