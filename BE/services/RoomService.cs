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

        public async Task<List<RoomDto>> GetAllAsync()
        {
            var rooms = await _repository.GetAllAsync();
            return rooms.Select(r => new RoomDto
            {
                Id = r.Id,
                Name = r.Name,
                Type = r.Type,
                Price = r.Price
            }).ToList();
        }

        public async Task<RoomDto?> GetByIdAsync(long id)
        {
            var r = await _repository.GetByIdAsync(id);
            if (r == null) return null;
            return new RoomDto { Id = r.Id, Name = r.Name, Type = r.Type, Price = r.Price };
        }

        public async Task<RoomDto> CreateAsync(RoomDto roomDto)
        {
            var room = new Room
            {
                Name = roomDto.Name,
                Type = roomDto.Type,
                Price = roomDto.Price
            };
            var created = await _repository.CreateAsync(room);
            return new RoomDto { Id = created.Id, Name = created.Name, Type = created.Type, Price = created.Price };
        }

        public async Task<RoomDto?> UpdateAsync(long id, RoomDto roomDto)
        {
            var room = new Room
            {
                Id = id,
                Name = roomDto.Name,
                Type = roomDto.Type,
                Price = roomDto.Price
            };
            var updated = await _repository.UpdateAsync(id, room);
            if (updated == null) return null;
            return new RoomDto { Id = updated.Id, Name = updated.Name, Type = updated.Type, Price = updated.Price };
        }

        public async Task<bool> DeleteAsync(long id) => await _repository.DeleteAsync(id);
    }
}
