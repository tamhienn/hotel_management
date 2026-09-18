//  thực thể ánh xạ tới bảnh users trong db

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BE.Entities
{
    [Table("Users")]
    public class User
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public string Username { get; set; } = string.Empty;    

        [Required]
        public string PasswordHash { get; set; } = string.Empty;

        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Role { get; set; } = "User";

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
 