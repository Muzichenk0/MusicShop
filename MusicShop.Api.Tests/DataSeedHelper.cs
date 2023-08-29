using MusicShop.DataAccess.Db;
using MusicShop.Domain.Models.User;

namespace MusicShop.Api.Tests
{
    public static class DataSeedHelper
    {
        //public static Guid TestInstTypeId { get; set; }
        public static Guid TestUserId { get; set; }

        public static void InitializeDbForTests(DbAppContext dbContext)
        {
            //InstrumentType testInstType = new InstrumentType
            //{
            //    CategoryName = "test_category"
            //};

            //dbContext.Add(testInstType);

            //TestInstTypeId = testInstType.Id;

            var testUser = new User
            {
                EMail = "test_mail",
                Id = Guid.NewGuid(),
                Password = "password",
                PhoneNumber = "+7-978-998-87-77",
                Rating = 5,
                Login = "test_login",
                Status = UserStatus.NotVerified,
                RegistratedIn = DateTime.UtcNow
            };
            TestUserId = testUser.Id;
            dbContext.Add(testUser);

            dbContext.SaveChanges();
        }
    }
}
