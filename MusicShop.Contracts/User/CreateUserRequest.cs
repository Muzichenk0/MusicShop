using MusicShop.Contracts.InstrumentType;
using MusicShop.Contracts.User.Enums;
using MusicShop.Contracts.ValidationAttributes;
using System.ComponentModel.DataAnnotations;

namespace MusicShop.Contracts.User
{
    /// <summary>
    /// ДТО модель, определяющая интерфейс, доступный запросу на создание пользователя.
    /// </summary>
    public sealed class CreateUserRequest
    {
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
        [PhoneNumber]
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Дата регистрации
        /// </summary>
        [Required]
        public DateTime RegistratedIn { get; set; }
        /// <summary>
        /// Статус учетной записи пользователяS
        /// </summary>
        [Required]
        public UserStatus Status { get; set; }
        /// <summary>
        /// Музыкальные квалификации пользователя.
        /// </summary>
        [Required]
        public ICollection<CreateInstrumentTypeRequest?> Qualifications { get; set; }
    }
}
