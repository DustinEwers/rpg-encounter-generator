using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RPGGen.CharacterService.Domain;


namespace RPGGen.CharacterService.Data
{
    public class InventoryItemEntityConfiguration : IEntityTypeConfiguration<InventoryItem>
    {
        public void Configure(EntityTypeBuilder<InventoryItem> builder)
        {
            builder.HasKey(x => new { x.ItemId, x.CharacterId });

            builder.Property(b => b.Notes).HasMaxLength(5000).IsRequired();

            builder.HasOne(x => x.Item).WithMany().HasForeignKey(x => x.ItemId);
            builder.HasOne(x => x.Character).WithMany(x=> x.InventoryItems).HasForeignKey(x => x.CharacterId);
        }
    }
}
