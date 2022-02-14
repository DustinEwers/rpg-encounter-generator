
namespace RPGGen.CharacterService.Domain.Services
{
    public interface IItemService {
        Task UpdateItem(Item item);
    }

    public class ItemService : IItemService
    {
        private readonly IAppDbContext _context;

        public ItemService(IAppDbContext context)
        {
            _context = context;
        }

        public async Task UpdateItem(Item item)
        {
            var it = _context.Items.First(x=> x.ItemId == item.ItemId);
            it.Description = item.Description;
            await _context.SaveChangesAsync();
        }
    }
}
