using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MusicShop.DataAccess.Contexts.MusicalInstrument
{
    public class MusicalInstrumentConfiguration : IEntityTypeConfiguration<Domain.Models.MusicalInstrument.MusicalInstrument>
    {
        public void Configure(EntityTypeBuilder<Domain.Models.MusicalInstrument.MusicalInstrument> entityBuilder)
        {
            entityBuilder
                .HasKey(i => i.Id);
            entityBuilder
                .Property(i => i.DateOfCreation)
                .HasConversion(d => d, d => DateTime.SpecifyKind(d, DateTimeKind.Utc));
        }
    }
}
