using BE.configs;
using BE.entities;
using BE.repositories;
using Microsoft.EntityFrameworkCore;

namespace BE.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly DatabaseConfig _dbcontext;

        public RoomRepository(DatabaseConfig dbcontext)
        {
            _dbcontext = dbcontext;
        }

        // Lấy tất cả phòng
        public async Task<List<Room>> GetAllRoom()
        {
            return await _dbcontext.Rooms

                .Include(r => r.RoomType)

                // tat ghi nho trang thai
                .AsNoTracking()

                // lay du lieu bang danh sach
                .ToListAsync();
        }

        // Lấy phòng theo ID
        public async Task<Room?> GetRoomById(int id)
        {
            return await _dbcontext.Rooms
                .Include(r => r.RoomType)
                .AsNoTracking()
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        // Thêm phòng
        public async Task<Room> CreateRoom(Room room)
        {
            _dbcontext.Rooms.Add(room);

            await _dbcontext.SaveChangesAsync();

            return await _dbcontext.Rooms
                .Include(r => r.RoomType)
                .AsNoTracking()
                .FirstAsync(r => r.Id == room.Id);
        }

        public async Task<Room?> UpdateRoom(int id, Room room)
        {
            var existingRoom = await _dbcontext.Rooms
                .FirstOrDefaultAsync(r => r.Id == id);

            if (existingRoom == null)
            {
                return null;
            }

            existingRoom.RoomNumber = room.RoomNumber;
            existingRoom.RoomTypeId = room.RoomTypeId;
            existingRoom.Floor = room.Floor;
            existingRoom.Status = room.Status;
            existingRoom.UpdatedAt = DateTime.Now;

            await _dbcontext.SaveChangesAsync();

            return await _dbcontext.Rooms
                .Include(r => r.RoomType)
                .AsNoTracking()
                .FirstAsync(r => r.Id == id);
        }

        // Xóa phòng
        public async Task<bool> DeleteRoom(int id)  
        {
            var room = await _dbcontext.Rooms
                .FirstOrDefaultAsync(r => r.Id == id);

            if (room == null)
            {
                return false;
            }

            _dbcontext.Rooms.Remove(room);

            await _dbcontext.SaveChangesAsync();

            return true;
        }
    }
}