using CoreApi.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CoreApi.CrossCutting
{
    public static class AuthDependencyInjection
    {
        public static IServiceCollection AddAuthPersistence(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AuthDbContext>(options =>
                options.UseNpgsql(connectionString));
            return services;
        }
    }
}
