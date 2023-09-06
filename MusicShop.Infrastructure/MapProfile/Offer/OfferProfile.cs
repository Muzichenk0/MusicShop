using AutoMapper;
using MusicShop.Contracts.Offer;

namespace MusicShop.Infrastructure.MapProfile.Offer
{
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
