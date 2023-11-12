using AutoMapper;
using MusicShop.Contracts.Offer;

namespace MusicShop.Infrastructure.MapProfile.Offer
{
    /// <summary>
    /// Ссылочный, конкретный тип, используемый для соотношения типа <see cref="Domain.Models.Offer.Offer"/> с иными и наоборот.
    /// </summary>
    public sealed class OfferProfile : Profile
    {
        public OfferProfile()
        {
            CreateMap<Domain.Models.Offer.Offer, OfferInfoResponse>()
                .ReverseMap();
            CreateMap<Domain.Models.Offer.Offer, CreateOfferRequest>()
                .ReverseMap();
            CreateMap<Domain.Models.Offer.Offer, UpdateOfferRequest>()
                .ReverseMap();
            CreateMap<Domain.Models.Offer.Offer, DeleteOfferRequest>()
                .ReverseMap();
        }
    }
}
