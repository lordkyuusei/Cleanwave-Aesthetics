using Cleanwave.Application.Common.Interfaces;
using Cleanwave.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace Cleanwave.Infrastructure
{
    public static class InfrastructureDependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddDbContext<CleanwaveDbContext>();
            services.AddScoped<ICleanwaveDbContext>();
            return services;
        }
    }
}
