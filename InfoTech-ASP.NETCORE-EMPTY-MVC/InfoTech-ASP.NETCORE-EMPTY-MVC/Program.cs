var builder = WebApplication.CreateBuilder(args);
//servis tanýmlamalarý builder

builder.Services.AddControllersWithViews();  //mvc kütüphanesini ekler

var app = builder.Build();
//middleware (ara katman) çalýþma zamanýnda uygulamaya eklenecek app ler

//localhost:portnumber/home/index/1

app.UseRouting(); //rotalama özelliðini çalýþtýr
app.UseStaticFiles(); //statik dosyalarý kullanýma aç (wwwroot)
app.UseHttpsRedirection(); //https'e redirect et

app.UseEndpoints(endpoints =>
endpoints.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"));

app.MapDefaultControllerRoute(); //default route ayarý

//app.MapGet("/", () => "Hello World!");

app.Run();
