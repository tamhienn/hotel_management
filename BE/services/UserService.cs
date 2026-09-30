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
            Fullname = user.Fullname,
            Email    = user.Email,
            PhoneNumber = user.PhoneNumber

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
        public async Task<UserResponseDto> CreateUser(CreateUserDto user)
        {
            var users = new User
            {
                Fullname = user.Fullname,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber

            };
            var rs = await _repository.CreateUser(users);
            return toDto(rs);
        }

        public async Task<UserResponseDto?> UpdateUser(int id, UpdateUserDto user)
        {
            var users = new User
            {
                Fullname = user.Fullname,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
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
