using BE.Dto;

namespace BE.Services
{
    public interface IUserService
    {
        Task<List<UserDto>> GetAllAsync();
        Task<UserDto?> GetByIdAsync(long id);
        Task<UserDto> CreateAsync(UserDto user);
        Task<UserDto?> UpdateAsync(long id, UserDto user);
        Task<bool> DeleteAsync(long id);
    }
}
