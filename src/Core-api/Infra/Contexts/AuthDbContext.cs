using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CoreApi.Domain;

namespace CoreApi.Infra.Contexts
{
    public class AuthDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options) { }
        // Customiza��es de mapping podem ser adicionadas aqui futuramente
    }
}
