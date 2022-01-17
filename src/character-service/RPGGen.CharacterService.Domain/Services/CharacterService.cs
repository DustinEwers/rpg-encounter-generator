using Microsoft.EntityFrameworkCore;

namespace RPGGen.CharacterService.Domain.Services
{
    public interface ICharacterService
    {
        Task<IEnumerable<Character>> GetCharacters();
        Task<Character> GetCharacter(Guid characterId);
        Task AddCharacter(Character value);
        Task UpdateCharacter(Guid id, Character value);
        Task DeleteCharacter(Guid id);
    }

    public class CharacterService : ICharacterService
    {
        private readonly IAppDbContext _context;

        public CharacterService(IAppDbContext context)
        {
            _context = context;
        }

        public async Task AddCharacter(Character value)
        {
            _context.Characters.Add(value);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCharacter(Guid id)
        {
            var item = await _context.Characters.FirstAsync();
            _context.Characters.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Character>> GetCharacters() => await _context.Characters.ToListAsync();

        public async Task<Character> GetCharacter(Guid characterId)
        {
            var character = await _context.Characters
                .Where(c => c.CharacterId == characterId)
                .Include("InventoryItems.Item")
                .FirstAsync();

            return character;
        }
        
        public async Task UpdateCharacter(Guid id, Character updatedItem)
        {
            var item = await _context.Characters.FirstAsync(x=> x.CharacterId == id);

            item.FirstName = updatedItem.FirstName;
            item.LastName = updatedItem.LastName;

            item.Strength = updatedItem.Strength;
            item.Dexterity = updatedItem.Dexterity;
            item.Constitution = updatedItem.Constitution;
            item.Intelligence = updatedItem.Intelligence;
            item.Wisdom = updatedItem.Wisdom;
            item.Charisma = updatedItem.Charisma;
            item.Backstory = updatedItem.Backstory;

            await _context.SaveChangesAsync();
        }
    }
}
