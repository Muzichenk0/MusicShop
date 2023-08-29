using AutoMapper;
using MusicShop.Contracts.User;

namespace MusicShop.Infrastructure.MapProfile.User
{
    /// <summary>
    /// Ссылочный, конкретный тип, используемый для соотношения типа <see cref="Domain.Models.User.User"/> с иными и наоборот.
    /// </summary>
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
