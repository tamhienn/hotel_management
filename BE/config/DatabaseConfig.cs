using Microsoft.EntityFrameworkCore;
using BE.Entities;

namespace BE.Config
{
    // Cầu nối giữa code C# và Database
    public class DatabaseConfig : DbContext
    {
        // options (connection string) được cấu hình ở Program.cs,
        public DatabaseConfig(DbContextOptions<DatabaseConfig> options) : base(options) { }

        public DbSet<Room> Rooms { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Room.cs đã có [Table("Rooms")] nên dòng dưới đây dư thừa, giữ lại cũng không sao
            modelBuilder.Entity<Room>().ToTable("Rooms");
        }
    }
}