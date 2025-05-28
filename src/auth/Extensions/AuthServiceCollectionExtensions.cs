using Auth.Interfaces;
using Auth.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Auth.Extensions
{
    public static class AuthServiceCollectionExtensions
    {
        public static IServiceCollection AddAuthServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            // Adicione outros servi�os relacionados � autentica��o aqui
            return services;
        }
    }
}
