using Microsoft.EntityFrameworkCore;
using WebApplicationPersonne.Models;

namespace WebApplicationPersonne
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //connexion Sql Server
            string sqlConnection = builder.Configuration.GetConnectionString("MaConnexion");
            builder.Services.AddDbContext<SqlServerContext>(options => options.UseSqlServer(sqlConnection));


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
                pattern: "{controller=Home}/{action=Index}/{id?}");
            //https://localhost:1234/monController/DisCoucou/a=2&b=4

            app.Run();
        }
    }
}