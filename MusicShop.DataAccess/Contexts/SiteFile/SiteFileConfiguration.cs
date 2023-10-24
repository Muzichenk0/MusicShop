using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MusicShop.DataAccess.Contexts.SiteFile
{
    public class SiteFileConfiguration : IEntityTypeConfiguration<Domain.Models.File.SiteFile>
    {
        public void Configure(EntityTypeBuilder<Domain.Models.File.SiteFile> builder)
        {
            builder.HasKey(f => f.Id);
        }
    }
}
