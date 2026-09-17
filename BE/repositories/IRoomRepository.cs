using BE.Entities;

namespace BE.Repositories
{
    public interface IRoomRepository
    {
        Task<List<Room>> GetAllAsync();
        Task<Room?> GetByIdAsync(long id);
        Task<Room> CreateAsync(Room room);
        Task<Room?> UpdateAsync(long id, Room room);
        Task<bool> DeleteAsync(long id);
    }
}
 