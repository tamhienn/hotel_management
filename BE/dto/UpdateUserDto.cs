// dùng để nhận dữ liệu từ client khi CẬP NHẬT user

namespace BE.Dto
{
    public class UpdateUserDto
    {
        public string Username { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}