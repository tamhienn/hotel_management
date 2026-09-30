using BE.dtos.Room;
using BE.entities;
using BE.repositories;

namespace BE.services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _repository;

        public RoomService(IRoomRepository repository)
        {
            _repository = repository;
        }


        // ==========================================
        // Chuyển Entity -> DTO
        // Dùng lại cho nhiều hàm
        // ==========================================

        private static RoomResponseDto ToDto(Room room) => new()
        {
            RoomNumber = room.RoomNumber,
            RoomTypeId = room.RoomTypeId,

            Name = room.RoomType.Name,
            BedCount = room.RoomType.BedCount,
            Capacity = room.RoomType.Capacity,
            Area = room.RoomType.Area,
            Price = room.RoomType.Price,

            Floor = room.Floor,
            Status = room.Status,

            CreatedAt = room.CreatedAt,
            UpdatedAt = room.UpdatedAt
        };


        // ==========================================
        // LẤY TẤT CẢ PHÒNG
        // ==========================================

        public async Task<List<RoomResponseDto>> GetAllRoom()
        {
            var rooms = await _repository.GetAllRoom();

            return rooms.Select(ToDto).ToList();
        }


        // ==========================================
        // LẤY PHÒNG THEO ID
        // ==========================================

        public async Task<RoomResponseDto?> GetRoomById(int id)
        {
            var room = await _repository.GetRoomById(id);

            return room == null
                ? null
                : ToDto(room);
        }


        // ==========================================
        // THÊM PHÒNG
        // ==========================================

        public async Task<RoomResponseDto> CreateRoom(CreateRoomDto dto)
        {
            var room = new Room
            {
                RoomNumber = dto.RoomNumber,
                RoomTypeId = dto.RoomTypeId,
                Floor = dto.Floor
            };

            var create = await _repository.CreateRoom(room);
            return ToDto(create);
        }


        // ==========================================
        // CẬP NHẬT PHÒNG
        // ==========================================

        public async Task<RoomResponseDto?> UpdateRoom(int id,UpdateRoomDto dto)
        {
            var room = new Room
            {
                RoomTypeId = dto.RoomTypeId,
                RoomNumber = dto.RoomNumber,
                Floor = dto.Floor,
                Status = dto.Status
            };

            var updated = await _repository.UpdateRoom(id, room);

            return updated == null
                ? null
                : ToDto(updated);
        }


        // ==========================================
        // XÓA PHÒNG
        // ==========================================

        public async Task<bool> DeleteRoom(int id)
        {
            return await _repository.DeleteRoom(id);
        }

       
    }
}