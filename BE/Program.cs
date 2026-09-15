using BE.Data;
using BE.Repository;
using BE.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    ));

// Đăng ký Repository room
builder.Services.AddScoped<RoomRepository>();

// Đăng ký Service room
builder.Services.AddScoped<RoomService>();

// Đăng ký Repository user
builder.Services.AddScoped<UserRepository>();

// Đăng ký Service user
builder.Services.AddScoped<UserService>();

var app = builder.Build();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();