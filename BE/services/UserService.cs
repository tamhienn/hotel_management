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

        private static UserDto ToDto(User user)
        {
            return new UserDto
            {
                Id = user.Id,
                FullName = user.FullName,
                DateOfBirth = user.DateOfBirth,
                Gender = user.Gender,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Role = user.Role,
                Status = user.Status,
                Address = user.Address,
                ImageUrl = user.ImageUrl,
                EmailVerifiedAt = user.EmailVerifiedAt,
                CreatedAt = user.CreatedAt,
                UpdatedAt = user.UpdatedAt
            };
        }

        public async Task<List<UserDto>> GetAllAsync()
        {
            var users = await _repository.GetAllAsync();

            return users.Select(ToDto).ToList();
        }

        public async Task<UserDto?> GetByIdAsync(int id)
        {
            var user = await _repository.GetByIdAsync(id);

            return user == null ? null : ToDto(user);
        }

        public async Task<UserDto> CreateAsync(CreateUserDto dto)
        {
            var user = new User
            {
                FullName = dto.FullName,
                DateOfBirth = dto.DateOfBirth,
                Gender = dto.Gender,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                PasswordHash = dto.PasswordHash,
                Role = dto.Role,
                Status = dto.Status,
                Address = dto.Address,
                ImageUrl = dto.ImageUrl,
                EmailVerifiedAt = dto.EmailVerifiedAt
            };

            var created = await _repository.CreateAsync(user);

            return ToDto(created);
        }

        public async Task<UserDto?> UpdateAsync(int id, UpdateUserDto dto)
        {
            var user = new User
            {
                FullName = dto.FullName,
                DateOfBirth = dto.DateOfBirth,
                Gender = dto.Gender,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                PasswordHash = dto.PasswordHash,
                Role = dto.Role,
                Status = dto.Status,
                Address = dto.Address,
                ImageUrl = dto.ImageUrl,
                EmailVerifiedAt = dto.EmailVerifiedAt
            };

            var updated = await _repository.UpdateAsync(id, user);

            return updated == null ? null : ToDto(updated);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}