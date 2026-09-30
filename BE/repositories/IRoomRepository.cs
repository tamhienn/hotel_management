using BE.entities;

namespace BE.repositories
{
    public interface IRoomRepository
    {

        Task<List<Room>> GetAllRoom();
        Task<Room?> GetRoomById(int Id);
        Task<Room> CreateRoom(Room room);
        Task<Room?> UpdateRoom(int id, Room room);
        Task<bool> DeleteRoom(int id);

    
    }
}
