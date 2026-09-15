using BE.Model;
using BE.Repository;

namespace BE.Service
{
    public class RoomService
    {
        private readonly RoomRepository repository;

        public RoomService(RoomRepository repository)
        {
            this.repository = repository;
        }
        
        // Get all rooms
        public async Task<List<RoomModel>> GetAllAsync()
        {
            return await repository.GetAllAsync();
        }

        // Get room by id
        public async Task<RoomModel?> GetByIdAsync(long id)
        {
            return await repository.GetByIdAsync(id);
        }

        // Create room
        public async Task<RoomModel> CreateAsync(RoomModel room)
        {
            return await repository.CreateAsync(room);
        }

        // Update room
        public async Task<RoomModel?> UpdateAsync(long id, RoomModel room)
        {
            return await repository.UpdateAsync(id, room);
        }

        // Delete room
        public async Task<bool> DeleteAsync(long id)
        {
            return await repository.DeleteAsync(id);
        }
    }
}