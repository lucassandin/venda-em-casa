using CoreApi.Infra;
using Microsoft.Extensions.DependencyInjection;

namespace CoreApi.CrossCutting
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddCoreApiPersistence(this IServiceCollection services, string connectionString)
        {
            services.AddPersistence(connectionString);
            return services;
        }
    }
}
