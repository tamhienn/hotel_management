using BE.Dto;

namespace BE.Services
{
    public interface IRoomService
    {
        Task<List<RoomDto>> GetAllAsync();
        Task<RoomDto?> GetByIdAsync(long id);
        Task<RoomDto> CreateAsync(RoomDto room);
        Task<RoomDto?> UpdateAsync(long id, RoomDto room);
        Task<bool> DeleteAsync(long id);
    }
}
