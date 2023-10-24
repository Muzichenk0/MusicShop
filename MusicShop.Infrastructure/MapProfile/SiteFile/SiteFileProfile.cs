using AutoMapper;
using MusicShop.Contracts.File;
using MusicShop.Domain.Models.File;

namespace MusicShop.Infrastructure.MapProfile.File
{
    /// <summary>
    /// Ссылочный, конкретный тип, используемый для соотношения типа <see cref="Domain.Models.File.SiteFile"/> с иными и наоборот.
    /// </summary>
    public sealed class SiteFileProfile : Profile
    {
        public SiteFileProfile()
        {
            CreateMap<SiteFile, CreateSiteFileRequest>()
                .ReverseMap();
            CreateMap<SiteFile, DeleteSiteFileRequest>()
                .ReverseMap();
            CreateMap<SiteFile, UpdateSiteFileRequest>()
                .ReverseMap();
            CreateMap<SiteFile, SiteFileInfoResponse>()
                .ReverseMap();
        }
    }
}
