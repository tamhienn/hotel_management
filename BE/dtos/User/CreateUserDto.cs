using System.ComponentModel.DataAnnotations;

namespace BE.dtos.User
{
    public class CreateUserDto
    {
        [Required]
        [MaxLength(50)]
        public string Fullname { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MaxLength(255)]
        public string Password { get; set; } = string.Empty;

        [MaxLength(20)]
        public string? PhoneNumber { get; set; }
    }
}