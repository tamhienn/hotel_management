using BE.Dto;

namespace BE.Services
{
    public interface IUserService
    {
        Task<List<UserDto>> GetAllAsync();
        Task<UserDto?> GetByIdAsync(long id);

        Task<UserDto> CreateAsync(CreateUserDto dto);

        Task<UserDto?> UpdateAsync(long id, UpdateUserDto dto);

        Task<bool> DeleteAsync(long id);
    }
}