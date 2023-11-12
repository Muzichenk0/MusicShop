using MusicShop.Contracts.InstrumentType;
using MusicShop.Contracts.SellerReview;
using MusicShop.Contracts.User.Enums;
using System.ComponentModel.DataAnnotations;

namespace MusicShop.Contracts.User
{
    /// <summary>
    /// Интерфейс, доступный, при создании ответа на запрос об информации, связанной с моделью пользователя.
    /// </summary>
    public sealed class UserInfoResponse
    {
        /// <summary>
        /// Идентификатор пользователя.
        /// </summary>
        [Required]
        public Guid Id { get; set; }
        /// <summary>
        /// Логин пользователя.
        /// </summary>
        [Required]
        public string Login { get; set; }
        /// <summary>
        /// Электронный, почтовый адрес пользователя.
        /// </summary>
        [Required]
        [EmailAddress]
        public string EMail { get; set; }
        //[Required]
        //public Domain.Models.User.UserStatus Status { get; set; }
        /// <summary>
        /// Дата регистрации пользователя.
        /// </summary>
        [Required]
        public DateTime RegistratedIn { get; set; }
        /// <summary>
        /// Номер телефона пользователя.
        /// </summary>
        [Required]
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Рейтинг пользователя, как продавца.
        /// </summary>
        [Required]
        [Range(0.00, 5.00)]
        public double Rating { get; set; }
        /// <summary>
        /// Статус учетной записи пользователя
        /// </summary>
        [Required]
        public UserStatus Status { get; set; }
        /// <summary>
        /// Полученные оценки пользователя, как продавца.
        /// </summary>
        [Required]
        public ICollection<SellerReviewInfoResponse> GainedReviews { get; set; }
        /// <summary>
        /// Отправленные оценки пользователя, как покупателя.
        /// </summary>
        [Required]
        public ICollection<SellerReviewInfoResponse> SendedReviews { get; set; }
        /// <summary>
        /// Музыкальная специализация текущего пользователя.
        /// </summary>
        [Required]
        public ICollection<InstrumentTypeInfoResponse> Qualifications { get; set; }
   
    }
}
