using BE.dtos.Login;
using BE.dtos.User;
using BE.entities;
using BE.repositories;
using BE.services;
using Microsoft.AspNetCore.Identity;

namespace BE.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _repository;
        private readonly IPasswordHasher<User> _passwordHasher;

        public AuthService(
            IUserRepository repository,
            IPasswordHasher<User> passwordHasher)
        {
            _repository = repository;
            _passwordHasher = passwordHasher;
        }

        public async Task<UserResponseDto> RegisterAsync(RegisterDto dto)
        {
            var existingUser = await _repository.GetByEmailAsync(dto.Email);

            if (existingUser != null)
            {
                throw new Exception("Email đã được sử dụng");
            }

            var user = new User
            {
                FullName = dto.FullName,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                Role = "user"
            };

            // hashpassword
            user.Password = _passwordHasher.HashPassword(
                user,
                dto.Password
            );

            var createdUser = await _repository.CreateAsync(user);

            return new UserResponseDto
            {
                Id = createdUser.Id,
                FullName = createdUser.FullName,
                Email = createdUser.Email,
                PhoneNumber = createdUser.PhoneNumber,
                AvatarUrl = createdUser.AvatarUrl,
                Role = createdUser.Role,
                CreatedAt = createdUser.CreatedAt,
                UpdatedAt = createdUser.UpdatedAt
            };
        }
    }
}