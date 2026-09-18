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

        // ---- mapping tái sử dụng: viết 1 lần, gọi lại ở mọi method bên dưới ----
        private static RoomDto ToDto(Room r) => new()
        {
            Id = r.Id,
            Name = r.Name,
            Type = r.Type,
            Price = r.Price,
            Description = r.Description,
            Status = r.Status
        };

        public async Task<List<RoomDto>> GetAllAsync()
        {
            var rooms = await _repository.GetAllAsync();
            return rooms.Select(ToDto).ToList();
        }

        public async Task<RoomDto?> GetByIdAsync(long id)
        {
            var r = await _repository.GetByIdAsync(id);
            return r == null ? null : ToDto(r);
        }

        public async Task<RoomDto> CreateAsync(CreateRoomDto dto)
        {
            var room = new Room
            {
                Name = dto.Name,
                Type = dto.Type,
                Price = dto.Price,
                Description = dto.Description,
                Status = "Available" 
            };

            var created = await _repository.CreateAsync(room);
            return ToDto(created);
        }

        public async Task<RoomDto?> UpdateAsync(long id, UpdateRoomDto dto)
        {
            var room = new Room
            {
                Name = dto.Name,
                Type = dto.Type,
                Price = dto.Price,
                Description = dto.Description,
                Status = dto.Status
            };

            var updated = await _repository.UpdateAsync(id, room);
            return updated == null ? null : ToDto(updated);
        }

        public async Task<bool> DeleteAsync(long id) => await _repository.DeleteAsync(id);
    }
}