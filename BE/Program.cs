using BE.Data;
using BE.Repository;
using BE.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// CORS cho phép React FE gọi API
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

// Cho phép FE gọi API
app.UseCors("AllowFE");

// app.UseHttpsRedirection();

app.MapControllers();

app.Run();