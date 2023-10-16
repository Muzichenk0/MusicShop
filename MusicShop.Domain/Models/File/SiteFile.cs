using MusicShop.Domain.Models.Base;

namespace MusicShop.Domain.Models.File
{
    public sealed class SiteFile : BaseEntity
    {
        public string Extension { get; set; }
        public string Name { get; set; }
        public byte[] Content { get; set; }
    }
}
