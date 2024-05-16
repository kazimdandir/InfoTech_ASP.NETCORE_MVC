var builder = WebApplication.CreateBuilder(args);
//servis tan�mlamalar� builder

builder.Services.AddControllersWithViews();  //mvc k�t�phanesini ekler

var app = builder.Build();
//middleware (ara katman) �al��ma zaman�nda uygulamaya eklenecek app ler

//localhost:portnumber/home/index/1

app.UseRouting(); //rotalama �zelli�ini �al��t�r
app.UseStaticFiles(); //statik dosyalar� kullan�ma a� (wwwroot)
app.UseHttpsRedirection(); //https'e redirect et

app.UseEndpoints(endpoints =>
endpoints.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"));

app.MapDefaultControllerRoute(); //default route ayar�

//app.MapGet("/", () => "Hello World!");

app.Run();
