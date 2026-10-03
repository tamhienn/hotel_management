using System.ComponentModel.DataAnnotations;

namespace BE.dtos.User
{
    public class UpdateUserDto
    {
        [Required]
        [MaxLength(50)]
        public string FullName { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [MaxLength(20)]
        public string? PhoneNumber { get; set; }

        [MaxLength(500)]
        public string? AvatarUrl { get; set; }

    }
}