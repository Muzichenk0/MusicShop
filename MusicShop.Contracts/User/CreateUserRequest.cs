using System.ComponentModel.DataAnnotations;

namespace MusicShop.Contracts.User
{
    /// <summary>
    /// ДТО модель, определяющая интерфейс, доступный запросу на создание пользователя.
    /// </summary>
    public sealed class CreateUserRequest
    {
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        [Required]
        public Guid Id { get; set; }
        /// <summary>
        /// Логин пользователя
        /// </summary>
        [Required]
        [StringLength(45)]
        public string Login { get; set; }
        /// <summary>
        /// Пароль пользователя
        /// </summary>
        [Required]
        public string Password { get; set; }
        /// <summary>
        /// Электронный, почтовый адрес пользователя
        /// </summary>
        [Required]
        [EmailAddress]
        public string EMail { get; set; }
        /// <summary>
        /// Телефонный номер пользователя
        /// </summary>
        [Required]
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Дата регистрации
        /// </summary>
        [Required]
        public DateTime RegistratedIn { get; set; }
    }
}
