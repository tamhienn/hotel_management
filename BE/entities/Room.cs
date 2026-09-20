using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BE.Entities
{
    [Table("rooms")]
    public class Room
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("room_type_id")]
        public int RoomTypeId { get; set; }

        [Column("room_number")]
        public string RoomNumber { get; set; } = string.Empty;

        [Column("floor")]
        public int Floor { get; set; }

        [Column("status")]
        public string Status { get; set; } = "available";

        [Column("description")]
        public string? Description { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }

        public RoomType? RoomType { get; set; }
    }
}