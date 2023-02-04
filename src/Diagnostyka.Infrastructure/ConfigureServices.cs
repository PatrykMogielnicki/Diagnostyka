using Diagnostyka.Application.Common.Interfaces;
using Diagnostyka.Infrastructure.Persistance;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IDiagnostykaDbContext>(provider => provider.GetService<DiagnostykaDbContext>());
            return services;
        }
    }
}
