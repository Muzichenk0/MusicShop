using AutoMapper;
using MusicShop.Contracts.SellerReview;
namespace MusicShop.Infrastructure.MapProfile.SellerReview
{
    public class SellerReviewProfile : Profile
    {
        public SellerReviewProfile()
        {
            CreateMap<Domain.Models.Review.SellerReview, CreateSellerReviewRequest>()
                .ReverseMap();
            CreateMap<Domain.Models.Review.SellerReview, DeleteSellerReviewRequest>()
                .ReverseMap();
            CreateMap<Domain.Models.Review.SellerReview, UpdateSellerReviewRequest>()
                .ReverseMap();
            CreateMap<Domain.Models.Review.SellerReview, SellerReviewResponseInfo>()
                .ReverseMap();
        }
    }
}
