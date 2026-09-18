//  thao tác crud trực tiếp vs database
//  implement IRoomRepository => hoàn thiện chức năng
//  sử dụng DatabaseConfig để truy cập db thông qua Entity framework core

using BE.Config;
using BE.Entities;
using Microsoft.EntityFrameworkCore;

namespace BE.Repositories
{
    // implement interface
    public class RoomRepository : IRoomRepository
    {

        // tạo field lưu đối tượng thao tác vs db
        private readonly DatabaseConfig _dbContext;

        // contructor nhận kiểu DatabaseConfig thông qua tham số dbContext tham chiếu đến object DatabaseConfig thao tác vs Db
        public RoomRepository(DatabaseConfig dbContext)
        {
            _dbContext = dbContext;
        }
        // hàm lấy tất cả room từ db => return list<room>
        public async Task<List<Room>> GetAllAsync() => await _dbContext.Rooms.ToListAsync();

        // get room by id
        public async Task<Room?> GetByIdAsync(long id) => await _dbContext.Rooms.FindAsync(id);

        // create room
        public async Task<Room> CreateAsync(Room room)
        {
            _dbContext.Rooms.Add(room);
            await _dbContext.SaveChangesAsync();
            return room;
        }

        // update room
        public async Task<Room?> UpdateAsync(long id, Room room)
        {
            var existingRoom = await _dbContext.Rooms.FindAsync(id);
            if (existingRoom == null) return null;

            //  lấy dữ liệu mới gán vào dữ liệu có sẵn
            existingRoom.Name = room.Name;
            existingRoom.Type = room.Type;
            existingRoom.Price = room.Price;
            existingRoom.Description = room.Description;
            existingRoom.Status = room.Status;

            await _dbContext.SaveChangesAsync();
            return existingRoom;
        }

        // delete room
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
