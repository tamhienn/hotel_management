// Thư viện Entity Framework Core
using Microsoft.EntityFrameworkCore;
using BE.Model;
// Namespace của thư mục Data
namespace BE.Data

{
    // Lớp kết nối Database
    public class AppDbContext : DbContext
    {
        // Constructor nhận cấu hình Database
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
//   DbSet quan li va truy cap data RoomModel 
        public DbSet<RoomModel> rooms { get; set; }

        //   DbSet quan li va truy cap data UserModel 
        public DbSet<UserModel> users { get; set; }
    }
}