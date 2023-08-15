using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MusicShop.DataAccess.Contexts.User
{
    public class UserConfiguration : IEntityTypeConfiguration<Domain.Models.User.User>
    {
        public void Configure(EntityTypeBuilder<Domain.Models.User.User> builder)
        {
            builder.HasKey(u => u.Id);
            builder.HasMany(u => u.Offers).WithOne(o => o.User).HasForeignKey(u => u.Id);
        }
    }
}
