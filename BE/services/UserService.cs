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

        public async Task<List<UserDto>> GetAllAsync()
        {
            var users = await _repository.GetAllAsync();
            return users.Select(u => new UserDto
            {
                Id = u.Id,
                Username = u.Username,
                FullName = u.FullName,
                Email = u.Email
            }).ToList();
        }

        public async Task<UserDto?> GetByIdAsync(long id)
        {
            var u = await _repository.GetByIdAsync(id);
            if (u == null) return null;
            return new UserDto { Id = u.Id, Username = u.Username, FullName = u.FullName, Email = u.Email };
        }

        public async Task<UserDto> CreateAsync(UserDto userDto)
        {
            var user = new User
            {
                Username = userDto.Username,
                FullName = userDto.FullName,
                Email = userDto.Email
            };
            var created = await _repository.CreateAsync(user);
            return new UserDto { Id = created.Id, Username = created.Username, FullName = created.FullName, Email = created.Email };
        }

        public async Task<UserDto?> UpdateAsync(long id, UserDto userDto)
        {
            var user = new User
            {
                Id = id,
                Username = userDto.Username,
                FullName = userDto.FullName,
                Email = userDto.Email
            };
            var updated = await _repository.UpdateAsync(id, user);
            if (updated == null) return null;
            return new UserDto { Id = updated.Id, Username = updated.Username, FullName = updated.FullName, Email = updated.Email };
        }

        public async Task<bool> DeleteAsync(long id) => await _repository.DeleteAsync(id);
    }
}
