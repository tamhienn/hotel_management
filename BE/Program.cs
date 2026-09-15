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

// Đăng ký Repository
builder.Services.AddScoped<IRoomRepository, RoomRepository>();

// Đăng ký Service
builder.Services.AddScoped<IRoomService, RoomService>();

// Đăng ký Repository
builder.Services.AddScoped<IUserRepository, UserRepository>();

// Đăng ký Service
builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();