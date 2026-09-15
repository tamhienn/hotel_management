using BE.Model;
using BE.Repository;

namespace BE.Service
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository repository;

        public RoomService(IRoomRepository repository)
        {
            this.repository = repository;
        }

        // get all rooms
        public async Task<List<RoomModel>> GetAllAsync()
        {
            return await repository.GetAllAsync();
        }

        //  get room by id
        public async Task<RoomModel?> GetByIdAsync(long id)
        {
            return await repository.GetByIdAsync(id);
        }

        // create room
        public async Task<RoomModel> CreateAsync(RoomModel room)
        {
            return await repository.CreateAsync(room);
        }

        // update room
        public async Task<RoomModel?> UpdateAsync(long id, RoomModel room)
        {
            return await repository.UpdateAsync(id, room);
        }

        // delete room
        public async Task<bool> DeleteAsync(long id)
        {
            return await repository.DeleteAsync(id);
        }
    }
}