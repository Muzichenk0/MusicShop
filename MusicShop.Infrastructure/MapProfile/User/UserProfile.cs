using AutoMapper;
using MusicShop.Contracts.User;

namespace MusicShop.Infrastructure.MapProfile.User
{
    /// <summary>
    /// Ссылочный, конкретный тип, используемый для соотношения типа <see cref="Domain.Models.User.User"/> с иными и наоборот.
    /// </summary>
    public sealed class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<Domain.Models.User.User, CreateUserRequest>()
                .ReverseMap()
                .ForMember(dest => dest.Qualifications, conf => conf.Ignore());

            //CreateMap<CreateUserRequest, Domain.Models.User.User>()
            //    .ForMember(destination => destination.Qualifications,
            //    config => config.MapFrom(src => src.Qualifications.Select(instTypeId => instTypeId).ToList()));

            CreateMap<Domain.Models.User.User, DeleteUserRequest>()
                .ReverseMap();
            CreateMap<Domain.Models.User.User, UpdateUserRequest>()
                .ReverseMap();
            CreateMap<Domain.Models.User.User, UserInfoResponse>()
                .ReverseMap();
        }
    }
}
