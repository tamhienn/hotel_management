using BE.entities;
using Microsoft.EntityFrameworkCore;

namespace BE.configs
{
    public class DatabaseConfig : DbContext
    {
        public DatabaseConfig(DbContextOptions<DatabaseConfig> options)
            : base(options)
        {
        }

        // ==============================
        // DbSet
        // ==============================

        public DbSet<Room> Rooms { get; set; }

        public DbSet<RoomType> RoomTypes { get; set; }

        public DbSet<User> Users { get; set; }


        // ==============================
        // Cấu hình Entity
        // ==============================

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ==============================
            // Quan hệ RoomType - Room
            // RoomType 1 ---- N Room
            // ==============================

            modelBuilder.Entity<Room>()
                .HasOne(r => r.RoomType)
                .WithMany(rt => rt.Rooms)
                .HasForeignKey(r => r.RoomTypeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}