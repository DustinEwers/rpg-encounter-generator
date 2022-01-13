using Microsoft.EntityFrameworkCore;
using RPGGen.CharacterService.Domain;

namespace RPGGen.CharacterService.Data
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public DbSet<Character> Characters {get;set;}

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
