namespace RPGGen.CharacterService.Domain
{
    public class InventoryItem
    {
        public Guid CharacterId { get; set; }
        public Guid ItemId { get; set; }

        public Item Item { get; set; }
        public Character Character { get; set; }
        
        public string Notes { get; set; } = string.Empty;
    }
}