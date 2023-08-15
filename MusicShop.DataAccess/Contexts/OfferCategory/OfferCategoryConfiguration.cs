using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace MusicShop.DataAccess.Contexts.OfferCategory
{
    public class OfferCategoryConfiguration : IEntityTypeConfiguration<Domain.Models.Offer.OfferCategory>
    {
        public void Configure(EntityTypeBuilder<Domain.Models.Offer.OfferCategory> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(c => c.Name).HasMaxLength(50);
        }
    }
}
