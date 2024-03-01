
using BusinessLogicLayer.Interface;
using BusinessLogicLayer.Repository;
using DataAccessLayer.Interface;
using DataAccessLayer.Models;
using DataAccessLayer.Repository;
using Microsoft.EntityFrameworkCore;

namespace ThreeTierArchitecture
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


			// Database Configuration
			var provider = builder.Services.BuildServiceProvider();
			var config = provider.GetService<IConfiguration>();
			builder.Services.AddDbContext<ThreeTierArchitectureStudentDbContext>(item => item.UseSqlServer(config.GetConnectionString("constr")));

			builder.Services.AddScoped<IStudentRepository, StudentRepository>();
			builder.Services.AddScoped<IStudentService, StudentService>();

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

			app.Run();
		}
	}
}
