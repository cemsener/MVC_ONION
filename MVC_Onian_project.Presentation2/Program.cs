using MVC_Onian_project.Presentation2.Extensions;
using MVC_ONION_PROJECT.APPLICATION.Extension;
using MVC_ONION_PROJECT.INFRASTRUCTURE.EXTENSION;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplicationService();
builder.Services.AddInfrastructureService(builder.Configuration);
//builder.Services.AddSeedDataService(builder.Configuration);
//migration atmadan bu kodu çalıştırma!!!!!! hata verir hangi getconnection kullanması gerekiyor diye sistem karışıyor
builder.Services.AddMvcService();



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
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapDefaultControllerRoute(); //area içinde olmayan controller sayfalarına gitmek için

app.Run();
