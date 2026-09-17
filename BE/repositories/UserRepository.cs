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

        public async Task<List<User>> GetAllAsync() => await _dbContext.Users.ToListAsync();

        public async Task<User?> GetByIdAsync(long id) => await _dbContext.Users.FindAsync(id);

        public async Task<User> CreateAsync(User user)
        {
            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<User?> UpdateAsync(long id, User user)
        {
            var existingUser = await _dbContext.Users.FindAsync(id);
            if (existingUser == null) return null;

            existingUser.Username = user.Username;
            existingUser.FullName = user.FullName;
            existingUser.Email = user.Email;
            existingUser.PhoneNumber = user.PhoneNumber;
            existingUser.Role = user.Role;

            await _dbContext.SaveChangesAsync();
            return existingUser;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var user = await _dbContext.Users.FindAsync(id);
            if (user == null) return false;

            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
