using System.ComponentModel.DataAnnotations;

namespace MusicShop.Contracts.User
{
    public sealed class UpdateUserRequest
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [EmailAddress]
        public string EMail { get; set; }
        [Required]
        [Range(0,5)]
        public double Rating { get; set; }


    }
}
