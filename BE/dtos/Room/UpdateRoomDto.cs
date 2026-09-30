namespace BE.dtos.Room
{
    public class UpdateRoomDto
    {
        public string RoomNumber { get; set; } = string.Empty;

        public int RoomTypeId { get; set; }

        public int Floor { get; set; }

        public string Status { get; set; } = string.Empty;


    }
}
