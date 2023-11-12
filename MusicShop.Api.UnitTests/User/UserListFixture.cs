using MusicShop.Contracts.InstrumentType;
using MusicShop.Contracts.User;

namespace Board.Tests
{
    public class UserListFixture
    {
        public UserListFixture()
        {
            List = Ids.Select(x => new UserInfoResponse
            {
                Id = x,
                EMail = "test_email@mail.ru",
                Login = "test_login",
                PhoneNumber = "+1-234-567-43-43",
                Status = MusicShop.Contracts.User.Enums.UserStatus.NotVerified,
                Rating = 4,
                RegistratedIn = DateTime.UtcNow,
                Qualifications = new List<InstrumentTypeInfoResponse>()
                {
                    new InstrumentTypeInfoResponse()
                    {
                        Id = x,
                        CategoryName = "test_category",
                        ParentId = null,
                        SubTypes = new List<InstrumentTypeInfoResponse>()
                    }
                },
            })
            .ToList();
        }

        public static Guid[] Ids { get; } = { Guid.NewGuid(), Guid.NewGuid(), Guid.Parse("09258252-083B-439A-931E-828E7F1B4F17") };

        public List<UserInfoResponse> List { get; }
    }
}