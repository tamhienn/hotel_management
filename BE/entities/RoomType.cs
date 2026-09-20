using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BE.Entities
{
    [Table("room_types")]
    public class RoomType
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; } = string.Empty;

        [Column("description")]
        public string? Description { get; set; }

        [Column("capacity")]
        public int Capacity { get; set; }

        [Column("base_price")]
        public decimal BasePrice { get; set; }

        [Column("image_url")]
        public string? ImageUrl { get; set; }

        [Column("status")]
        public string Status { get; set; } = "active";

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }

        public ICollection<Room> Rooms { get; set; } = new List<Room>();
    }
}