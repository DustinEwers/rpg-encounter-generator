namespace RPGGen.CharacterService.Domain
{
    public class Item
    {
        public Guid ItemId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}