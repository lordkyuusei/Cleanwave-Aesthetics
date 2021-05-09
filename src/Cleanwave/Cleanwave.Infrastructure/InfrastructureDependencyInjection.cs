using Cleanwave.Application.Common.Interfaces;
using Cleanwave.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Cleanwave.Infrastructure
{
    public static class InfrastructureDependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CleanwaveDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("CleanwaveDatabase"),
                    b => b.MigrationsAssembly(typeof(CleanwaveDbContext).Assembly.FullName)));

            services.AddScoped<ICleanwaveDbContext>(provider => provider.GetService<ICleanwaveDbContext>());
            return services;
        }
    }
}
