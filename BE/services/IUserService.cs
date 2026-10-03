using BE.dtos.User;

namespace BE.services
{
    public interface IUserService
    {
        Task<List<UserResponseDto>> GetAllUser();
        Task<UserResponseDto?> GetUserById(int id);
        Task<UserResponseDto?> UpdateUser(int id, UpdateUserDto room);
        Task<bool> DeleteUser(int id);
    }
}
