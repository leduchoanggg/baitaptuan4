using Microsoft.EntityFrameworkCore;
using baitaptuan4.Models; // Sử dụng namespace dự án của bạn

var builder = WebApplication.CreateBuilder(args);

// Đăng ký StudentDbContext kết nối SQL Server
builder.Services.AddDbContext<StudentDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Cấu hình Route mặc định
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=SinhVien}/{action=Index}/{id?}");

app.Run();