namespace BE.Dto
{
    public class CreateRoomDto
    {
        public int RoomTypeId { get; set; }

        public string RoomNumber { get; set; } = string.Empty;

        public int Floor { get; set; }

        public string Status { get; set; } = "available";

        public string? Description { get; set; }
    }
}