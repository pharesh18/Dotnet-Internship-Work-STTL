
using Microsoft.EntityFrameworkCore;
using OrderManagementAPI.Models;
using OrderManagementAPI.Interface;
using OrderManagementAPI.Repository;

namespace OrderManagementAPI
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

			var provider = builder.Services.BuildServiceProvider();
			var config = provider.GetService<IConfiguration>();
			builder.Services.AddDbContext<OrderManagementSystemDbContext>(item => item.UseSqlServer(config.GetConnectionString("constr"))); // Configuring the connection string. 

			builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();	     // Injecting Customer repository with Customer Interface
			builder.Services.AddScoped<IProductRepository, ProductRepository>();		 // Injecting Product repository with Product Interface
			builder.Services.AddScoped<IOrderRepository, OrderRepository>();			 // Injecting Order repository with Order Interface
			builder.Services.AddScoped<IOrderItemRepository, OrderItemRepository>();     // Injecting OrderItem repository with OrderItem Interface

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
