using System.ComponentModel.DataAnnotations;

namespace MusicShop.Contracts.User
{
    public sealed class CreateUserRequest
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        [StringLength(45)]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [EmailAddress]
        public string EMail { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public DateTime RegistratedIn { get; set; }
    }
}
