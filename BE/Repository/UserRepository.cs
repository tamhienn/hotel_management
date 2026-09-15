using BE.Data;
using BE.Model;
using Microsoft.EntityFrameworkCore;

namespace BE.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext appDbContext;

        public UserRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        // Get all rooms
        public async Task<List<UserMoel>> GetAllAsync()
        {
            return await appDbContext.users.ToListAsync();
        }
    }
}