using BE.Dto;
using BE.Entities;
using BE.Repositories;

namespace BE.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _repository;

        public RoomService(IRoomRepository repository)
        {
            _repository = repository;
        }

        private static RoomDto ToDto(Room r) => new()
        {
            Id = r.Id,
            RoomTypeId = r.RoomTypeId,
            RoomNumber = r.RoomNumber,
            Floor = r.Floor,
            Status = r.Status,
            Description = r.Description,
            CreatedAt = r.CreatedAt,
            UpdatedAt = r.UpdatedAt
        };

        public async Task<List<RoomDto>> GetAllAsync()
        {
            var rooms = await _repository.GetAllAsync();

            return rooms.Select(ToDto).ToList();
        }

        public async Task<RoomDto?> GetByIdAsync(int id)
        {
            var room = await _repository.GetByIdAsync(id);

            return room == null ? null : ToDto(room);
        }

        public async Task<RoomDto> CreateAsync(CreateRoomDto dto)
        {
            var room = new Room
            {
                RoomTypeId = dto.RoomTypeId,
                RoomNumber = dto.RoomNumber,
                Floor = dto.Floor,
                Status = dto.Status,
                Description = dto.Description
            };

            var created = await _repository.CreateAsync(room);

            return ToDto(created);
        }

        public async Task<RoomDto?> UpdateAsync(
            int id,
            UpdateRoomDto dto)
        {
            var room = new Room
            {
                RoomTypeId = dto.RoomTypeId,
                RoomNumber = dto.RoomNumber,
                Floor = dto.Floor,
                Status = dto.Status,
                Description = dto.Description
            };

            var updated = await _repository.UpdateAsync(id, room);

            return updated == null ? null : ToDto(updated);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}