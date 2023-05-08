using Microsoft.EntityFrameworkCore;
using WebApplicationDemo2023.Models;

namespace WebApplicationDemo2023
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //récupération de la chaine de connexion dans appsettings
            //et connexion à la base
            string connectionString = builder.Configuration.GetConnectionString("MaConnexion");
            builder.Services.AddDbContext<SqlServerContext>(
                options => options.UseSqlServer(connectionString));

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Indexa}/{id?}");

            app.Run();
        }
    }
}