using MusicShop.Domain.Models.Base;

namespace MusicShop.Domain.Models.User
{
    /// <summary>
    ///  Cущность, определяющая интерфейс пользователя. Реализует <see cref="BaseEntity"/>
    /// </summary>
    public class User : BaseEntity
    {
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
        /// Навигационное свойство в отношении многие ко многим между сущностями: <see cref="User"/> и <see cref="InstrumentType.InstrumentType"/>
        /// </summary>
        public ICollection<InstrumentType.InstrumentType> Qualifications { get; set; }
        /// <summary>
        /// Номер телефона пользователя.
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Предложения, открытые пользователем.
        /// Навигационное свойство в отношении один ко многим, между зависимой <see cref="User"/> и главной <see cref="Offer.Offer"
        /// </summary>
        public ICollection<Offer.Offer?> Offers { get; set; }
        /// <summary>
        /// Предложения, закрытые пользователем.
        /// Навигационное свойство в отношении один ко многим, между зависимой <see cref="User"/> и главной <see cref="Offer.Offer"
        /// </summary>
        public ICollection<Offer.Offer?> ClosedOffers { get; set; }
        /// <summary>
        /// Рейтинг пользователя.
        /// </summary>
        public double Rating { get; set; }
        /// <summary>
        /// Полученные отзывы о проданных товарах.
        /// Навигационное свойство в отношении один ко многим между зависимой <see cref="User"/> и главной <see cref="Review.SellerReview"/>
        /// </summary>
        public ICollection<Review.SellerReview?> GainedReviews { get; set; }
        /// <summary>
        /// Отправленные отзывы о купленных товарах.
        /// Навигационное свойство в отношении один ко многим между зависимой <see cref="User"/> и главной <see cref="Review.SellerReview"/>
        /// </summary>
        public ICollection<Review.SellerReview?> SendedReviews { get; set; }
        
    }
}