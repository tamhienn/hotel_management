using BE.dtos.Room;
namespace BE.services
{
    public interface IRoomService
    {

        Task<List<RoomResponseDto>> GetAllRoom();
        Task<RoomResponseDto?> GetRoomById(int Id);
        Task<RoomResponseDto> CreateRoom(CreateRoomDto room);
        Task<RoomResponseDto?> UpdateRoom(int id, UpdateRoomDto room);
        Task<bool> DeleteRoom(int id);

    }
}
