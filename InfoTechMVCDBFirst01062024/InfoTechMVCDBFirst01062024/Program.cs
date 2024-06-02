using InfoTechMVCDBFirst01062024.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Veritabanýna baðlantý servisi
//builder.Services.AddDbContext<NorthwindContext>(x => x.UseSqlServer("Server=KAZIM\\SQLExpress;Database=Northwind;Trusted_Connection=True;"));

//2.alternatif
var ConnectionString = builder.Configuration.GetConnectionString("Baglanti");
builder.Services.AddDbContext<NorthwindContext>(x => x.UseSqlServer(ConnectionString));

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
