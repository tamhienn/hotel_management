using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BE.entities
{
    [Table("rooms")]
    public class Room
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("room_number")]
        public string RoomNumber { get; set; } = string.Empty;

        [Column("room_type_id")]
        public int RoomTypeId { get; set; }

        [Column("floor")]
        public int Floor { get; set; }

        [Column("status")]
        public string Status { get; set; } = "available";

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }

        // Quan hệ N - 1 với RoomType
        public RoomType RoomType { get; set; } = null!;
    }
}