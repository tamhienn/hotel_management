using BE.configs;
using BE.entities;
using Microsoft.EntityFrameworkCore;

namespace BE.repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly DatabaseConfig _dbcontext;
        public UserRepository(DatabaseConfig dbContext)
        {
            _dbcontext = dbContext;
        }

        public async Task<List<User>> GetAllUser()
        {
            return await _dbcontext.Users
                // tat ghi nho trang thai
                .AsNoTracking()

                // lay du lieu dang danh sach
                .ToListAsync();


        }

        public async Task<User?> GetUserById(int id)
        {
            return await _dbcontext.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(r => r.Id == id);
        }


        public async Task<User?> UpdateUser(int id, User user)
        {
            var existingUser = await _dbcontext.Users
                .FirstOrDefaultAsync(r => r.Id == id);

            if (existingUser == null)
            {
                return null;
            }
            existingUser.FullName = user.FullName;
            existingUser.Email = user.Email;
            existingUser.PhoneNumber = user.PhoneNumber;
            existingUser.AvatarUrl = user.AvatarUrl;
            existingUser.UpdatedAt = DateTime.Now;

            await _dbcontext.SaveChangesAsync();

            return await _dbcontext.Users
                .AsNoTracking()
                .FirstAsync(r => r.Id == id);
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _dbcontext.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(r => r.Email == email);
        }

        public async Task<User> CreateAsync(User user)
        {
            _dbcontext.Users.Add(user);
            await _dbcontext.SaveChangesAsync();
            return await _dbcontext.Users
                .AsNoTracking()
                .FirstAsync(r => r.Id == user.Id);
        }

        public async Task<bool> DeleteUser(int id)
        {
            var rs = await _dbcontext.Users
                .FirstOrDefaultAsync(r => r.Id == id);

            if(rs == null)
            {
                return false;
            }

            _dbcontext.Users.Remove(rs);
            await _dbcontext.SaveChangesAsync();
            return true;
        }
    }
}
