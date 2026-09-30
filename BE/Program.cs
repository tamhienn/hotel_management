// builder.Service la noi dang ky va quan li cac dich vua cua ung dung

using BE.configs;
using BE.repositories;
using BE.Repositories;
using BE.services;
using Microsoft.EntityFrameworkCore;

// ==================================================
// NHÓM 1 — CẤU HÌNH
// ==================================================

var builder = WebApplication.CreateBuilder(args);


// 1. cau hinh controller => nhan dien cac thuoc tinh [Route("api/[controller]")], [HttpGet], [HttpPost]
builder.Services.AddControllers();

// 2. cau hinh cors => cho phep fe goi api lay va gui data
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFE", policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

// 3. cau hinh Database
builder.Services.AddDbContext<DatabaseConfig>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    );
});

// Đăng ký Repository & Service cho Room
builder.Services.AddScoped<IRoomRepository, RoomRepository>();
builder.Services.AddScoped<IRoomService, RoomService>();

// Đăng ký Reposiitory & Service cho User
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

// Tạo ứng dụng từ các cấu hình ở trên
var app = builder.Build();




// ==================================================
// NHÓM 2 — CHẠY ỨNG DỤNG
// ==================================================

// Cho phép FE gọi API
app.UseCors("AllowFE");

// HTTPS hiện tại chưa sử dụng
// app.UseHttpsRedirection();

// Kích hoạt các Controller
app.MapControllers();

// Khởi chạy Backend
app.Run();

