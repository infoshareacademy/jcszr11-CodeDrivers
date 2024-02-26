using CodeDriversMVC.DataAccess;
using CodeDriversMVC.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Threading.RateLimiting;

namespace CodeDriversMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<CodeDriversContext>();
            builder.Services.AddScoped<RegistrationService>();
            builder.Services.AddScoped<CarService>();
            builder.Services.AddScoped<LoginService>();
            builder.Services.AddScoped<ReservationService>();
            builder.Services.AddAutoMapper(typeof(Program).Assembly);
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddAuthentication().AddCookie();
            builder.Services.AddAuthorization();

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
            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}