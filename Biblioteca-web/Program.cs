using Biblioteca.Infrestructure.Context;
using Microsoft.EntityFrameworkCore;
using Biblioteca.IOC.Dependencies;
using Biblioteca_web.Services;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<Bibliotecacontext>(options => options.UseSqlServer
                                                        (builder.Configuration.GetConnectionString("BibliotecaContext")));
builder.Services.AddLectorDependency();
builder.Services.AddHttpClient();
builder.Services.AddTransient<ILectorApiService, LectorApiService>();
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
