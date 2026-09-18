// đóng gói dữ liệu để truyền giữa các bên (client - server) thông qua api
// dùng để TRẢ VỀ (response) — không dùng làm input cho Create/Update

namespace BE.Dto
{
    public class RoomDto
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
    }
}