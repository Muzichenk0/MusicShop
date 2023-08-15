using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace MusicShop.DataAccess.Contexts.Offer
{
    public class OfferConfiguration : IEntityTypeConfiguration<Domain.Models.Offer.Offer>
    {
        public void Configure(EntityTypeBuilder<Domain.Models.Offer.Offer> builder)
        {
            builder.HasKey(u => u.Id);
            builder.HasMany(o => o.OfferCategories).WithOne(o => o.Offer).HasForeignKey(o => o.Id);
        }
    }

}
