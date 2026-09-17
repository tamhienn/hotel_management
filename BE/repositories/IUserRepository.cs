using BE.Entities;

namespace BE.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync();
        Task<User?> GetByIdAsync(long id);
        Task<User> CreateAsync(User user);
        Task<User?> UpdateAsync(long id, User user);
        Task<bool> DeleteAsync(long id);
    }
}
