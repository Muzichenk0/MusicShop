using AutoMapper;
using MusicShop.Contracts.SellerReview;
namespace MusicShop.Infrastructure.MapProfile.SellerReview
{
    /// <summary>
    /// Ссылочный, конкретный тип, используемый для соотношения типа <see cref="Domain.Models.Review.SellerReview"/> с иными и наоборот.
    /// </summary>
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
            CreateMap<Domain.Models.Review.SellerReview, SellerReviewInfoResponse>()
                .ReverseMap();
        }
    }
}
