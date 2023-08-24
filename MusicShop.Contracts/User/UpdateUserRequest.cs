using System.ComponentModel.DataAnnotations;

namespace MusicShop.Contracts.User
{
    /// <summary>
    /// ДТО модель, определяющая интерфейс для запроса на обновление пользователя.
    /// </summary>
    public sealed class UpdateUserRequest
    {
        [Required]
        public Guid Id { get; set; }
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
        [Range(0,5)]
        public double Rating { get; set; }


    }
}
