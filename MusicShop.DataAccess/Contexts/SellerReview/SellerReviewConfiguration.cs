using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MusicShop.DataAccess.Contexts.SellerReview
{
    public class SellerReviewConfiguration : IEntityTypeConfiguration<Domain.Models.Review.SellerReview>
    {
        public void Configure(EntityTypeBuilder<Domain.Models.Review.SellerReview> entityBuilder)
        {
            entityBuilder.HasKey(r => r.Id);
            entityBuilder.Property(r => r.Topic).HasMaxLength(65);
            entityBuilder.Property(r => r.Description).HasMaxLength(300);
            //entityBuilder
            //    .HasOne(r => r.User)
            //    .WithMany(u => u.GainedReviews)
            //    .HasForeignKey(r => r.UserId).OnDelete(DeleteBehavior.NoAction);
            //entityBuilder
            //    .HasOne(r => r.Sender)
            //    .WithMany(u => u.SendedReviews)
            //    .HasForeignKey(r => r.SenderId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
