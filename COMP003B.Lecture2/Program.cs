using Microsoft.AspNetCore.Builder;

namespace COMP003B.Lecture2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

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

            // middleware

            //Welcome page at /welcome
            app.UseWelcomePage("/welcome");
            // added HTTP error code middleware
            app.UseStatusCodePages();
            app.UseHttpsRedirection();
            app.UseStaticFiles(); // uses wwwroot on solution explorer

            app.UseRouting();

            app.UseAuthorization(); // insert secrets that the user cant access

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
