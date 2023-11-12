using MusicShop.Contracts.User.Enums;
using MusicShop.Contracts.ValidationAttributes;
using System.ComponentModel.DataAnnotations;

namespace MusicShop.Contracts.User
{
    /// <summary>
    /// ДТО модель, определяющая интерфейс, доступный запросу на изменение данных, связанных с моделью пользователя.
    /// </summary>
    public sealed class UpdateUserRequest
    {
        /// <summary>
        /// Логин пользователя.
        /// </summary>
        [Required]
        public string Login { get; set; }
        /// <summary>
        /// Обновление информации о пользователе.
        /// </summary>
        [Required]
        public string Password { get; set; }
        /// <summary>
        /// Адрес электронной почты пользователя.
        /// </summary>
        [Required]
        [EmailAddress]
        public string EMail { get; set; }
        /// <summary>
        /// Рейтинг пользователя.
        /// </summary>
        [Required]
        [Range(0.00,5.00)]
        public double Rating { get; set; }
        /// <summary>
        /// Статус учетной записи пользователя
        /// </summary>
        [Required]
        public UserStatus Status { get; set; }
        /// <summary>
        /// Номер телефона пользователя.
        /// </summary>
        [Required]
        [PhoneNumber]
        public string PhoneNumber { get; set; }
    }
}
