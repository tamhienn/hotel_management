using BE.Dto;

namespace BE.Services
{
    public interface IRoomService
    {
        Task<List<RoomDto>> GetAllAsync();
        Task<RoomDto?> GetByIdAsync(long id);

        Task<RoomDto> CreateAsync(CreateRoomDto dto);

        Task<RoomDto?> UpdateAsync(long id, UpdateRoomDto dto);

        Task<bool> DeleteAsync(long id);
    }
}