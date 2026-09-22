// DTO dùng để nhận dữ liệu từ client khi CẬP NHẬT user
// không có Id, PasswordHash (đổi mật khẩu nên tách API riêng), CreatedAt, GoogleId, LoginProvider

namespace BE.Dto
{
    public class UpdateUserDto
    {
        public string FullName { get; set; } = string.Empty;

        public DateTime? DateOfBirth { get; set; }

        public string? Gender { get; set; }

        public string Email { get; set; } = string.Empty;

        public string? PhoneNumber { get; set; }

        public string PasswordHash { get; set; } = string.Empty;

        public string Role { get; set; } = "user";

        public string Status { get; set; } = "active";

        public string? Address { get; set; }

        public string? ImageUrl { get; set; }

        public DateTime? EmailVerifiedAt { get; set; }
    }
}