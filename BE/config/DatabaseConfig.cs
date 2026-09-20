using BE.Entities;
using Microsoft.EntityFrameworkCore;

namespace BE.Config
{
    public class DatabaseConfig : DbContext
    {
        public DatabaseConfig(DbContextOptions<DatabaseConfig> options)
            : base(options)
        {
        }

        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Room>().ToTable("rooms");
            modelBuilder.Entity<RoomType>().ToTable("room_types");
            modelBuilder.Entity<User>().ToTable("users");

            modelBuilder.Entity<Room>()
                .HasOne(r => r.RoomType)
                .WithMany(rt => rt.Rooms)
                .HasForeignKey(r => r.RoomTypeId);
        }
    }
}