using BE.Entities;

namespace BE.Repositories
{
    public interface IRoomRepository
    {
        // các interface định nghĩa chức năng
        Task<List<Room>> GetAllAsync();
        Task<Room?> GetByIdAsync(long id);
        Task<Room> CreateAsync(Room room);
        Task<Room?> UpdateAsync(long id, Room room);
        Task<bool> DeleteAsync(long id);
    }
}
 