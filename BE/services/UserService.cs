using BE.Dto;
using BE.Entities;
using BE.Repositories;

namespace BE.Services
{

    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        // ---- mapping tái sử dụng: viết 1 lần, gọi lại ở mọi method bên dưới ----
        // Chuyển đổi đối tượng User Entity sang UserDto
        private static UserDto ToDto(User u) => new()
        {
            Id = u.Id,
            Username = u.Username,
            FullName = u.FullName,
            Email = u.Email
        };


        public async Task<List<UserDto>> GetAllAsync()
        {
            var users = await _repository.GetAllAsync();
            return users.Select(ToDto).ToList();
        }

        public async Task<UserDto?> GetByIdAsync(long id)
        {
            var u = await _repository.GetByIdAsync(id);
            return u == null ? null : ToDto(u);
        }

        // Chuyển dữ liệu từ CreateUserDto sang User Entity để lưu vào database
        public async Task<UserDto> CreateAsync(CreateUserDto dto)
        {
            var user = new User
            {
                Username = dto.Username,
                FullName = dto.FullName,
                Email = dto.Email
            };

            var created = await _repository.CreateAsync(user);
            return ToDto(created);
        }

        public async Task<UserDto?> UpdateAsync(long id, UpdateUserDto dto)
        {
            var user = new User
            {
                Username = dto.Username,
                FullName = dto.FullName,
                Email = dto.Email
            };

            var updated = await _repository.UpdateAsync(id, user);
            return updated == null ? null : ToDto(updated);
        }

        public async Task<bool> DeleteAsync(long id) => await _repository.DeleteAsync(id);
    }
}