using BE.Config;
using BE.Entities;
using Microsoft.EntityFrameworkCore;

namespace BE.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly DatabaseConfig _dbContext;

        public RoomRepository(DatabaseConfig dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Room>> GetAllAsync() => await _dbContext.Rooms.ToListAsync();

        public async Task<Room?> GetByIdAsync(long id) => await _dbContext.Rooms.FindAsync(id);

        public async Task<Room> CreateAsync(Room room)
        {
            _dbContext.Rooms.Add(room);
            await _dbContext.SaveChangesAsync();
            return room;
        }

        public async Task<Room?> UpdateAsync(long id, Room room)
        {
            var existingRoom = await _dbContext.Rooms.FindAsync(id);
            if (existingRoom == null) return null;

            existingRoom.Name = room.Name;
            existingRoom.Type = room.Type;
            existingRoom.Price = room.Price;
            existingRoom.Description = room.Description;
            existingRoom.Status = room.Status;

            await _dbContext.SaveChangesAsync();
            return existingRoom;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var room = await _dbContext.Rooms.FindAsync(id);
            if (room == null) return false;

            _dbContext.Rooms.Remove(room);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
