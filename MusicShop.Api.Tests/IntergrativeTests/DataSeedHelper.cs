using MusicShop.DataAccess.Db;
using MusicShop.Domain.Models.InstrumentType;
using MusicShop.Domain.Models.Offer;
using MusicShop.Domain.Models.Review;
using MusicShop.Domain.Models.User;
using System.Collections.ObjectModel;

namespace MusicShop.Api.Tests.IntegrationTests
{
    /// <summary>
    /// Источник с данными, использующийся для инициализаций таблиц при инициализации БД.
    /// </summary>
    public static class DataSeedHelper
    {
        public static Guid TestInstTypeId { get; set; }
        public static Guid TestUserId { get; set; }
        public static Guid TestOfferId { get; set; }
        public static Guid TestSellerReviewId { get; set; }
        static DataSeedHelper()
        {
            TestInstTypeId = Guid.NewGuid();
            TestUserId = Guid.NewGuid();
            TestOfferId = Guid.NewGuid();
            TestSellerReviewId = Guid.NewGuid();
        }
        public static void InitializeDbForTests(DbAppContext dbContext)
        {
            User testUser = new User
            {
                EMail = "test_mail",
                Id = TestUserId,
                Password = "test_password",
                PhoneNumber = "+7-978-998-87-77",
                Rating = 5,
                Login = "test_login",
                Status = UserStatus.NotVerified,
                RegistratedIn = DateTime.UtcNow
            };
            dbContext.Add(testUser);

            Offer testOffer = new Offer()
            {
                Id = Guid.NewGuid(),
                Description = "test_description",
                Discount = 0,
                ClosedUserId = TestUserId,
                OfferCategoryId = TestOfferId,
                OfferState = Domain.Models.Offer.OfferState.OfferState.Opened,
                UserId = TestUserId,
                RequirePrice = 2500
            };
            dbContext.Add(testOffer);

            InstrumentType testInstType = new InstrumentType()
            {
                Id = Guid.NewGuid(),
                CategoryName = "test_category",
                SubTypes = null,
                Users = new ObservableCollection<User?>() { testUser },
                ParentId = null,
                OfferId = TestOfferId
            };
            dbContext.Add(testInstType);

            SellerReview testSellerReview = new SellerReview()
            {
                Id = Guid.NewGuid(),
                UserId = TestUserId,
                Date = DateTime.UtcNow,
                Description = "test_description",
                Rating = 5,
                SenderId = TestUserId,
                Topic = "test_topic"
            };
            dbContext.Add(testSellerReview);

            dbContext.SaveChanges();
        }
    }
}
