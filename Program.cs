using FreelanceManager.Interfaces;
using FreelanceManager.Models;
using FreelanceManager.Repositry;
using Microsoft.EntityFrameworkCore;

namespace FreelanceManager
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

        
            builder.Services.AddDbContext<ITIContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("cs")));


            builder.Services.AddScoped<IProjectRepo, ProjectRepo>();
            builder.Services.AddScoped<IClientRepo, ClientRepo>();
            builder.Services.AddScoped<IFreelancerRepo, FreelancerRepo>();
            builder.Services.AddScoped<IInvoiceRepo, InvoiceRepo>();
            builder.Services.AddScoped<IMissionRepo, MissionRepo>();
            builder.Services.AddScoped<ITimeTrackingRepo, TimeTrackingRepo>();
            builder.Services.AddScoped<IMissionRepo, MissionRepo>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
