using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using DemoBusiness.Data;
using DemoBusiness.Data.Services;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
// Add services to the container.
// configure connection string

builder.Services.AddDbContext<AppDbContext>(options => 
options.UseSqlServer(configuration.GetConnectionString("DefaultConnectionString")));

builder.Services.AddScoped<IUserBusiness,UserBusiness>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

//Seed database FOR FIRST TIME LOGIN
// AppDbInitializer.Seed(app);
app.Run();
