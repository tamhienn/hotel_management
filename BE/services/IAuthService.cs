using BE.dtos.Login;
using BE.dtos.User;

namespace BE.services
{
    public interface IAuthService
    {
        Task<UserResponseDto> RegisterAsync(RegisterDto dto);
    }
}
