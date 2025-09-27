
using API.Services;
using DingoBox.Data;
using DingoBox.Models;
using DingoBox.Services;
using Microsoft.EntityFrameworkCore;

namespace DingoBox
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Đăng ký các dịch vụ
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer(); // Bắt buộc
            builder.Services.AddSwaggerGen();           // Bắt buộc
            builder.Services.AddDbContext<MyContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
                     new MySqlServerVersion(new Version(8, 0, 30))));

            builder.Services.AddScoped<IDictionaryEntry, DictionaryEntryRepository>();
            var app = builder.Build();

            // Bật Swagger UI nếu đang ở môi trường Development
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger(); // Bắt buộc để tạo swagger.json
                app.UseSwaggerUI(); // Bắt buộc để hiển thị giao diện Swagger
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

       

            app.Run();
        }
    }
}
