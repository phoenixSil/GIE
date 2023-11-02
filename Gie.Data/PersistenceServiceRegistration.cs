using Castle.Core.Configuration;
using Gie.Api.Datas;
using Gie.Api.Repertoires;
using Gie.Features.Contrats.Repertoires;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MsCommun.Extensions;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace Gie.Data.Extensions
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSqlServerDbConfiguration<EtudiantDbContext>(configuration);

            services.AddScoped<IPointDaccess, PointDaccess>();
            services.AddScoped<IRepertoireDetudiant, RepertoireDetudiant>();
            services.AddScoped<IRepertoireDadresse, RepertoireDadresse>();
            services.AddScoped<IRepertoireDeNiveau, RepertoireDeNiveau>();

            return services;
        }
    } 
}
