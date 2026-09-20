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

        public async Task<List<Room>> GetAllAsync()
        {
            return await _dbContext.Rooms
                .Include(r => r.RoomType)
                .ToListAsync();
        }

        public async Task<Room?> GetByIdAsync(int id)
        {
            return await _dbContext.Rooms
                .Include(r => r.RoomType)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<Room> CreateAsync(Room room)
        {
            room.CreatedAt = DateTime.UtcNow;
            room.UpdatedAt = DateTime.UtcNow;

            _dbContext.Rooms.Add(room);

            await _dbContext.SaveChangesAsync();

            return room;
        }

        public async Task<Room?> UpdateAsync(int id, Room room)
        {
            var existingRoom = await _dbContext.Rooms.FindAsync(id);

            if (existingRoom == null)
                return null;

            existingRoom.RoomTypeId = room.RoomTypeId;
            existingRoom.RoomNumber = room.RoomNumber;
            existingRoom.Floor = room.Floor;
            existingRoom.Status = room.Status;
            existingRoom.Description = room.Description;

            existingRoom.UpdatedAt = DateTime.UtcNow;

            await _dbContext.SaveChangesAsync();

            return existingRoom;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var room = await _dbContext.Rooms.FindAsync(id);

            if (room == null)
                return false;

            _dbContext.Rooms.Remove(room);

            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}