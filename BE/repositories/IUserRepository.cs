using BE.entities;

namespace BE.repositories
{
    public interface IUserRepository
    {
        public Task<List<User>> GetAllUser();

        public Task<User?> GetUserById(int id);

        public Task<User?> GetByEmailAsync(string email);

        public Task<User> CreateAsync(User user);

        public Task<User?> UpdateUser(int id, User user);

        public Task<bool> DeleteUser(int id);
    }
}
