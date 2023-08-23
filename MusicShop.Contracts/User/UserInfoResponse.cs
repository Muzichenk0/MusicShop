using System.ComponentModel.DataAnnotations;

namespace MusicShop.Contracts.User
{
    /// <summary>
    /// ДТО модель, для передачи информации о пользователе,
    /// через ответ от сервера на запросы.
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
        [Range(0, 5)]
        public double Rating { get; set; }
    }
}
