// dùng để nhận dữ liệu từ client khi CẬP NHẬT phòng
// không có Id vì Id đã lấy từ route param (VD: PUT /api/rooms/{id})

namespace BE.Dto
{
    public class UpdateRoomDto
    {
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty; // cho phép sửa, VD: Available -> Booked
    }
}