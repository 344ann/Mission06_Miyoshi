using Microsoft.EntityFrameworkCore;
using Mission06_Miyoshi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<MovieContext>(options => { options.UseSqlite(builder.Configuration["ConnectionStrings:MovieConnection"]);});
var app = builder.Build(); // Build the application pipeline

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) // Check if the environment is NOT development
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection(); // Redirect HTTP requests to HTTPS
app.UseStaticFiles(); // Serve static files like CSS, JavaScript, and images

app.UseRouting(); // Enable request routing

app.UseAuthorization(); // Enable authorization middleware

// Define the default route for the application
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"); // Default to HomeController and Index action

app.Run();