using BE.Model;

namespace BE.Repository
{
    public interface IRoomRepository
    {
        // get all room
        Task<List<RoomModel>> GetAllAsync();

        // get room by id
        Task<RoomModel?> GetByIdAsync(long id);

        // create room
        Task<RoomModel> CreateAsync(RoomModel room);

        // update room
        Task<RoomModel?> UpdateAsync(long id, RoomModel room);

        // delete room
        Task<bool> DeleteAsync(long id);
    }
}