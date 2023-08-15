using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace MusicShop.DataAccess.Contexts.InstrumentType
{
    public class InstrumentTypeConfiguration : IEntityTypeConfiguration<Domain.Models.MusicalInstrument.MusicalInstrumentType.InstrumentType>
    {
        public void Configure(EntityTypeBuilder<Domain.Models.MusicalInstrument.MusicalInstrumentType.InstrumentType> builder)
        {
            builder.HasKey(u => u.Id);
            builder.HasMany(t => t.MusicalInstruments).WithOne(i => i.InstrumentType).HasForeignKey(o => o.Id);
        }
    }
}
