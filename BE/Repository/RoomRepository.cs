using BE.Data;
using BE.Model;
using Microsoft.EntityFrameworkCore;

namespace BE.Repository
{
    public class RoomRepository
    {
        private readonly AppDbContext appDbContext;

        public RoomRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        // Get all rooms
        public async Task<List<RoomModel>> GetAllAsync()
        {
            return await appDbContext.rooms.ToListAsync();
        }

        // Get room by id
        public async Task<RoomModel?> GetByIdAsync(long id)
        {
            return await appDbContext.rooms.FindAsync(id);
        }

        // Create room
        public async Task<RoomModel> CreateAsync(RoomModel room)
        {
            appDbContext.rooms.Add(room); // Thêm room vào DB

            await appDbContext.SaveChangesAsync(); // Lưu thay đổi vào DB

            return room;
        }

        // Update room
        public async Task<RoomModel?> UpdateAsync(long id, RoomModel room)
        {
            var existingRoom = await appDbContext.rooms.FindAsync(id);

            if (existingRoom == null)
            {
                return null;
            }

            existingRoom.Name = room.Name;
            existingRoom.Type = room.Type;
            existingRoom.Price = room.Price;
            existingRoom.Description = room.Description;
            existingRoom.Status = room.Status;

            await appDbContext.SaveChangesAsync();

            return existingRoom;
        }

        // Delete room
        public async Task<bool> DeleteAsync(long id)
        {
            var room = await appDbContext.rooms.FindAsync(id);

            if (room == null)
            {
                return false;
            }

            appDbContext.rooms.Remove(room);

            await appDbContext.SaveChangesAsync();

            return true;
        }
    }
}