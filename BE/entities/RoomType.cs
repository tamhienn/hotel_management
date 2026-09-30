using BE.entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BE.entities
{
    [Table("room_types")]
    public class RoomType
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; } = string.Empty;

        [Column("bed_count")]
        public int BedCount { get; set; }

        [Column("capacity")]
        public int Capacity { get; set; }

        [Column("area")]
        public decimal Area { get; set; }

        [Column("price")]
        public decimal Price { get; set; }

        [Column("description")]
        public string? Description { get; set; }

        [Column("img_url")]
        public string? ImgUrl { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }

        // Quan hệ RoomType 1 - N Room
        public ICollection<Room> Rooms { get; set; } = new List<Room>();
    }
}