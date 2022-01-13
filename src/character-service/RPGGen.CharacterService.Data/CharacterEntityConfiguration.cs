using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RPGGen.CharacterService.Domain;


namespace RPGGen.CharacterService.Data
{
    public class CharacterEntityConfiguration : IEntityTypeConfiguration<Character>
    {
        public void Configure(EntityTypeBuilder<Character> builder)
        {
            builder.HasKey(x => x.CharacterId);

            builder.Property(b => b.FirstName).HasMaxLength(50).IsRequired();
            builder.Property(b => b.LastName).HasMaxLength(50).IsRequired();
            builder.Property(b => b.Backstory).HasMaxLength(5000).IsRequired();
        }
    }
}
