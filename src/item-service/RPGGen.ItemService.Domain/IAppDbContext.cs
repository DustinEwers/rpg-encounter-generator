using Microsoft.EntityFrameworkCore;

namespace RPGGen.ItemService.Domain
{
    public interface IAppDbContext
    {
        DbSet<Item> Items { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    }
}