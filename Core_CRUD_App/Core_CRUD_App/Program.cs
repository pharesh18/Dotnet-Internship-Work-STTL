using Core_CRUD_App.Models;
using Core_CRUD_App.Repository;
using Microsoft.EntityFrameworkCore;

namespace Core_CRUD_App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();


            // Database Configuration
            var provider = builder.Services.BuildServiceProvider();
            var config = provider.GetService<IConfiguration>();
            builder.Services.AddDbContext<CoreCrudAppContext>(item => item.UseSqlServer(config.GetConnectionString("constr")));

            builder.Services.AddScoped<IStudentRepository, StudentRepository>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Student/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Student}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
