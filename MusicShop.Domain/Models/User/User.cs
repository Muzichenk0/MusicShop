using System.ComponentModel.DataAnnotations;
using MusicShop.Domain.Models.ModelType;
using MusicShop.Domain.Models.MusicalInstrument.MusicalInstrumentType;

namespace MusicShop.Domain.Models.User
{
    /// <summary>
    ///  Cущность, определяющая интерфейс пользователя. Реализует <see cref="IIdentificable"/>
    /// </summary>
    public class User : IIdentificable
    {
        [Required]
        public Guid Id { get; set; }
        /// <summary>
        /// Логин пользователя.
        /// </summary>
        [Required]
        public string Login { get; set; }
        /// <summary>
        /// Пароль пользователя .
        /// </summary>
        [Required]
        public string Password { get; set; }
        /// <summary>
        /// Электронный, почтовый адрес пользователя.
        /// </summary>
        [Required]
        [EmailAddress]
        public string EMail { get; set; }
        /// <summary>
        /// Статус пользователя .
        /// </summary>
        [Required]
        public UserStatus Status { get; set; }
        /// <summary>
        /// Дата регистрации пользователя .
        /// </summary>
        [Required]
        public DateTime RegistratedIn { get; set; }
        /// <summary>
        /// Инструментальная специализация.
        /// </summary>
        public IReadOnlyCollection<InstrumentType?> MusicalSpecialization { get; set; }
        /// <summary>
        /// Номер телефона пользователя
        /// </summary>
        [Required]
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Предложения, открытые пользователем.
        /// </summary>
        [Required]
        public ICollection<Offer.Offer?> Offers { get; set; }
        /// <summary>
        /// Рейтинг пользователя.
        /// </summary>
        [Required]
        [Range(0,5)]
        public double Rating { get; set; }
        /// <summary>
        /// Полученные оценки о проданных товарах.
        /// Навигационное свойство в отношении один ко многим между глав. сущностью <see cref="User"/> и завис. <see cref="Review.SellerReview"/>
        /// </summary>
        public ICollection<Review.SellerReview?> GainedReviews { get; set; }
        /// <summary>
        /// Отправленные оценки о купленных товарах.
        /// Навигационное свойство в отношении один ко многим между глав. сущностью <see cref="User"/> и завис. <see cref="Review.SellerReview"/>
        /// </summary>
        public ICollection<Review.SellerReview?> SendedReviews { get; set; }
        
    }
}