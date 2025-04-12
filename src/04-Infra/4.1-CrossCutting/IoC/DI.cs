using ddd.Application.Interfaces;
using ddd.Application.Services;
using ddd.Data;
using ddd.Data.Interfaces;
using ddd.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace ddd.IoC
{
    public static class DI
    {
        public static void AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            
            services.AddSingleton(configuration);

            services.AddDbContext<ProjectContext>(options =>
                    options.UseNpgsql(configuration["CONNECTION_STRING"]));
           

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<IEntityRepository, EntityRepository>();
            services.AddScoped<IService, Service>();
        }
    }
}