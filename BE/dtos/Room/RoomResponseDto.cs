using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BE.dtos.Room
{
    public class RoomResponseDto
    {

        public string RoomNumber { get; set; } = string.Empty;

        public int RoomTypeId { get; set; }

        public string Name { get; set; } = string.Empty;

        public int BedCount { get; set; }

        public int Capacity { get; set; }

        public decimal Area { get; set; }

        public decimal Price { get; set; }


        public int Floor { get; set; }

        public string Status { get; set; } = "available";

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
