using Microsoft.EntityFrameworkCore;
using RPGGen.ItemService.Domain;

namespace RPGGen.ItemService.Data
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public DbSet<Item> Items { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
