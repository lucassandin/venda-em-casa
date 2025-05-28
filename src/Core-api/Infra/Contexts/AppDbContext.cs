using Microsoft.EntityFrameworkCore;

namespace CoreApi.Infra.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Adicione seus DbSets aqui, por exemplo:
        // public DbSet<YourEntity> YourEntities { get; set; }
    }
}
