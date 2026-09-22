using BE.Config;
using BE.Entities;
using Microsoft.EntityFrameworkCore;

namespace BE.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseConfig _dbContext;

        public UserRepository(DatabaseConfig dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _dbContext.Users.FindAsync(id);
        }

        public async Task<User> CreateAsync(User user)
        {
            user.CreatedAt = DateTime.UtcNow;
            user.UpdatedAt = DateTime.UtcNow;

            _dbContext.Users.Add(user);

            await _dbContext.SaveChangesAsync();

            return user;
        }

        public async Task<User?> UpdateAsync(int id, User user)
        {
            var existingUser = await _dbContext.Users.FindAsync(id);

            if (existingUser == null)
                return null;

            existingUser.FullName = user.FullName;
            existingUser.DateOfBirth = user.DateOfBirth;
            existingUser.Gender = user.Gender;
            existingUser.Email = user.Email;
            existingUser.PhoneNumber = user.PhoneNumber;
            existingUser.PasswordHash = user.PasswordHash;
            existingUser.Role = user.Role;
            existingUser.Status = user.Status;
            existingUser.Address = user.Address;
            existingUser.ImageUrl = user.ImageUrl;
            existingUser.EmailVerifiedAt = user.EmailVerifiedAt;

            existingUser.UpdatedAt = DateTime.UtcNow;

            await _dbContext.SaveChangesAsync();

            return existingUser;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var user = await _dbContext.Users.FindAsync(id);

            if (user == null)
                return false;

            _dbContext.Users.Remove(user);

            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}