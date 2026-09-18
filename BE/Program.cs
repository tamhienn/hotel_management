using BE.Config;
using BE.Repositories;
using BE.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Đăng ký Controllers
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

// Đăng ký DbContext 
builder.Services.AddDbContext<DatabaseConfig>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    ));

// Đăng ký Repository & Service cho Room
builder.Services.AddScoped<IRoomRepository, RoomRepository>();
builder.Services.AddScoped<IRoomService, RoomService>();

// Đăng ký Repository & Service cho User
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

// Cho phép FE gọi API
app.UseCors("AllowFE");

// Nếu muốn bật HTTPS thì mở dòng dưới
// app.UseHttpsRedirection();

app.MapControllers();

app.Run();
