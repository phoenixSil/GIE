using Gie.Api.Datas;
using Gie.Api.Repertoires;
using Gie.Api.Repertoires.Contrats;
using Microsoft.EntityFrameworkCore;

namespace Gie.Api.Extensions
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped<IPointDaccess, PointDaccess>();

            services.AddScoped<IRepertoireDetudiant, RepertoireDetudiant>();
            services.AddScoped<IRepertoireDadresse, RepertoireDadresse>();
            services.AddScoped<IRepertoireDeNiveau, RepertoireDeNiveau>();

            return services;
        }
    }
}
