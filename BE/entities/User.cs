using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BE.Entities
{
    [Table("users")]
    public class User
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("full_name")]
        public string FullName { get; set; } = string.Empty;

        [Column("date_of_birth")]
        public DateTime? DateOfBirth { get; set; }

        [Column("gender")]
        public string? Gender { get; set; }

        [Column("email")]
        public string Email { get; set; } = string.Empty;

        [Column("phone_number")]
        public string? PhoneNumber { get; set; }

        [Column("password_hash")]
        public string PasswordHash { get; set; } = string.Empty;

        [Column("role")]
        public string Role { get; set; } = "user";

        [Column("status")]
        public string Status { get; set; } = "active";

        [Column("address")]
        public string? Address { get; set; }

        [Column("image_url")]
        public string? ImageUrl { get; set; }

        [Column("email_verified_at")]
        public DateTime? EmailVerifiedAt { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}