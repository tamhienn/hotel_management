
namespace BE.dtos.Room
{
    public class CreateRoomDto
    {
        public string RoomNumber { get; set; } = string.Empty;

        public int RoomTypeId { get; set; }

        public int Floor { get; set; }

    }
}
