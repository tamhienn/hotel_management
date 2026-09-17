using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BE.Entities
{
    [Table("Rooms")]
    public class Room
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public string Type { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public string Description { get; set; } = string.Empty;

        public string Status { get; set; } = string.Empty;

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
 