using Microsoft.EntityFrameworkCore;
using RPGGen.CharacterService.Domain;

namespace RPGGen.CharacterService.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Character> Characters {get;set;}

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public const string  SCHEMA = "character";

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(SCHEMA);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
