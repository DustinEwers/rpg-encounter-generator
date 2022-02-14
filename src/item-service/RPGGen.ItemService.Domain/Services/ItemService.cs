using Dapr.Client;
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
        private readonly DaprClient _daprClient;

        const string storeName = "item-store";
        const string key = "item-list";

        public ItemService(IAppDbContext context, DaprClient daprClient) => (_context, _daprClient) = (context, daprClient);

        public async Task AddItem(Item value)
        {
            _context.Items.Add(value);
            await _context.SaveChangesAsync();

            // Clear out the cache
            await _daprClient.DeleteStateAsync(storeName, key);
        }

        public async Task DeleteItem(Guid id)
        {
            var item = await _context.Items.FirstAsync();
            _context.Items.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Item>> GetItems()
        {
            var cachedItems = await _daprClient.GetStateAsync<IEnumerable<Item>>(storeName, key);
            if (cachedItems == null) {
                Thread.Sleep(2000); // Pretend this takes a while
                return await _context.Items.ToListAsync();
            }

            return cachedItems;
        }

        public async Task UpdateItem(Guid id, Item updatedItem)
        {
            var item = await _context.Items.FirstAsync(x => x.ItemId == id);
            item.Name = updatedItem.Name;
            item.Description = updatedItem.Description;
            await _context.SaveChangesAsync();

            await _daprClient.PublishEventAsync("dnd-app-pubsub", "items", item);

            // Clear out the cache
            await _daprClient.DeleteStateAsync(storeName, key);
        }
    }
}
