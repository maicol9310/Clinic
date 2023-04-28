using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Clinic.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Clinic.Infrastructure.Persistence;

namespace Clinic.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // Add framework services.
            services.AddDbContext<ClinicDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("ConnectionClinic"),
                sqlServerOptionsAction: sqlOptions =>
                {
                    sqlOptions.MigrationsAssembly(typeof(ClinicDbContext).GetTypeInfo().Assembly.GetName().Name);

                    sqlOptions.EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
                });
            }, ServiceLifetime.Scoped);


            services.AddScoped<IClinicDbContext>(provider => provider.GetService<ClinicDbContext>());


            return services;
        }

    }
}
