
using FleetManagement.Model;
using Microsoft.EntityFrameworkCore;

namespace FleetManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            var b = builder.Configuration.GetConnectionString("default");
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContextPool<FleetContext>((op) => op.UseSqlServer(b));

            builder.Services.AddCors((p) => p.AddDefaultPolicy(
                                                policy => policy.WithOrigins("*").
                                                           AllowAnyHeader()
                                                              .AllowAnyMethod()
                                                              )
                        );
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();
            app.UseCors();

            app.Run();
        }
    }
}