using Microsoft.EntityFrameworkCore;
using BE.Entities;

namespace BE.Config
{
    public class DatabaseConfig : DbContext
    {
        public DatabaseConfig(DbContextOptions<DatabaseConfig> options) : base(options) { }

        public DbSet<Room> Rooms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Room>().ToTable("Rooms");
        }
    }
}
