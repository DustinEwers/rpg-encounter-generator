using Microsoft.EntityFrameworkCore;

namespace RPGGen.CharacterService.Domain
{
    public interface IAppDbContext
    {
        DbSet<Character> Characters { get; set; }
        DbSet<Item> Items { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
