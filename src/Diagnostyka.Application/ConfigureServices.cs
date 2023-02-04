using Diagnostyka.Application.Common;
using Diagnostyka.Application.Common.Interfaces;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IItemManager, ItemManager>();
            services.AddScoped<IKolorManager, KolorManager>();
            return services;
        }
    }
}
