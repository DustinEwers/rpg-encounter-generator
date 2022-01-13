using Microsoft.EntityFrameworkCore;

namespace RPGGen.ItemService.Domain.Services
{
    public interface IItemService {
        Task<IEnumerable<Item>> GetItems();
        Task AddItem(Item value);
        Task UpdateItem(Guid id, Item value);
        Task DeleteItem(Guid id);
    }

    public class ItemService : IItemService
    {
        private readonly IAppDbContext _context;

        public ItemService(IAppDbContext context)
        {
            _context = context;
        }

        public async Task AddItem(Item value)
        {
            _context.Items.Add(value);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteItem(Guid id)
        {
            var item = await _context.Items.FirstAsync();
            _context.Items.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Item>> GetItems()
        {
            return await _context.Items.ToListAsync();
        }

        public async Task UpdateItem(Guid id, Item updatedItem)
        {
            var item = await _context.Items.FirstAsync(x => x.ItemId == id);
            item.Name = updatedItem.Name;
            item.Description = updatedItem.Description;
            await _context.SaveChangesAsync();
        }
    }
}
