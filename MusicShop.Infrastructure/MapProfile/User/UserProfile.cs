using AutoMapper;
using MusicShop.Contracts.User;

namespace MusicShop.Infrastructure.MapProfile.User
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<Domain.Models.User.User, CreateUserRequest>()
                .ReverseMap();
            CreateMap<Domain.Models.User.User, DeleteUserRequest>()
                .ReverseMap();
            CreateMap<Domain.Models.User.User, UpdateUserRequest>()
                .ReverseMap();
            CreateMap<Domain.Models.User.User, UserInfoResponse>()
                .ReverseMap();
        }
    }
}
