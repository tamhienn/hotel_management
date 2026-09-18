// dùng để nhận dữ liệu từ client khi TẠO phòng mới
// không có Id vì Id do DB tự sinh, client không được tự set

namespace BE.Dto
{
    public class CreateRoomDto
    {
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Description { get; set; } = string.Empty;

    }
}