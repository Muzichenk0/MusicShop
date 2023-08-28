using MusicShop.Domain.Models.ModelType;
using MusicShop.Domain.Models.MusicalInstrument.InstrumentType;

namespace MusicShop.Domain.Models.User
{
    /// <summary>
    ///  Cущность, определяющая интерфейс пользователя. Реализует <see cref="IIdentificable"/>
    /// </summary>
    public class User : IIdentificable
    {
        public Guid Id { get; set; }
        /// <summary>
        /// Логин пользователя.
        /// </summary>
        public string Login { get; set; }
        /// <summary>
        /// Пароль пользователя.
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Электронный, почтовый адрес пользователя.
        /// </summary>
        public string EMail { get; set; }
        /// <summary>
        /// Статус пользователя.
        /// </summary>
        public UserStatus Status { get; set; }
        /// <summary>
        /// Дата регистрации пользователя.
        /// </summary>
        public DateTime RegistratedIn { get; set; }
        /// <summary>
        /// Инструментальная специализация.
        /// </summary>
        public IReadOnlyCollection<InstrumentType> MusicalSpecialization { get; set; }
        /// <summary>
        /// Номер телефона пользователя.
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Предложения, открытые пользователем.
        /// </summary>
        public ICollection<Offer.Offer?> Offers { get; set; }
        /// <summary>
        /// Рейтинг пользователя.
        /// </summary>
        public double Rating { get; set; }
        /// <summary>
        /// Полученные отзывы о проданных товарах.
        /// Навигационное свойство в отношении один ко многим между глав. сущностью <see cref="User"/> и завис. <see cref="Review.SellerReview"/>
        /// </summary>
        public ICollection<Review.SellerReview?> GainedReviews { get; set; }
        /// <summary>
        /// Отправленные отзывы о купленных товарах.
        /// Навигационное свойство в отношении один ко многим между глав. сущностью <see cref="User"/> и завис. <see cref="Review.SellerReview"/>
        /// </summary>
        public ICollection<Review.SellerReview?> SendedReviews { get; set; }
        
    }
}