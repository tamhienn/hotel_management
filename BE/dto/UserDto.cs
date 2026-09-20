// DTO dùng để trả dữ liệu user về cho client (response)
// KHÔNG bao giờ trả PasswordHash ra ngoài vì lý do bảo mật

namespace BE.Dto
{
    public class UserDto
    {
        public int Id { get; set; }

        public string Username { get; set; } = string.Empty;

        public string FullName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string? PhoneNumber { get; set; }

        public string Role { get; set; } = string.Empty;

        public string Status { get; set; } = string.Empty;

        public string? Address { get; set; }

        public string? ImageUrl { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}