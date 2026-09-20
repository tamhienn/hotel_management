namespace BE.Dto
{
    public class RoomDto
    {
        public int Id { get; set; }

        public int RoomTypeId { get; set; }

        public string RoomNumber { get; set; } = string.Empty;

        public int Floor { get; set; }

        public string Status { get; set; } = string.Empty;

        public string? Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}