namespace BE.Dto
{
    public class CreateUserDto
    {
        public string Username { get; set; } = string.Empty;

        public string FullName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string? PhoneNumber { get; set; }

        public string PasswordHash { get; set; } = string.Empty;

        public string Role { get; set; } = "user";

        public string Status { get; set; } = "active";

        public string? Address { get; set; }

        public string? ImageUrl { get; set; }
    }
}