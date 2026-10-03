using BE.dtos.User;
using BE.repositories;
using BE.entities;
using System.Linq;

namespace BE.services
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        private static UserResponseDto toDto(User user) => new()
        {
            Id = user.Id,
            FullName = user.FullName,
            Email = user.Email,
            PhoneNumber = user.PhoneNumber,
            AvatarUrl = user.AvatarUrl,
            Role = user.Role,
            CreatedAt = user.CreatedAt,
            UpdatedAt = user.UpdatedAt
        };

        public async Task<List<UserResponseDto>> GetAllUser()
        {
            var rs = await _repository.GetAllUser();

            return rs.Select(toDto).ToList();
        }

        public async Task<UserResponseDto?> GetUserById(int id)
        {
            var rs = await _repository.GetUserById(id);
            return rs == null ? null : toDto(rs);
        }

        public async Task<UserResponseDto?> UpdateUser(int id, UpdateUserDto user)
        {
            var users = new User
            {
                FullName = user.FullName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                AvatarUrl = user.AvatarUrl
            };

            var rs = await _repository.UpdateUser(id, users);

            return rs == null
                ? null
                : toDto(rs);
        }

        public async Task<bool> DeleteUser(int id)
        {
            return await _repository.DeleteUser(id);
        }



        
    }
}
