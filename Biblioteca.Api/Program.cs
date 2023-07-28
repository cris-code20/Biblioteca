using Biblioteca.Application.Contract;
using Biblioteca.Application.Service;
using Biblioteca.Infrestructure.Context;
using Biblioteca.Infrestructure.Interface;
using Biblioteca.Infrestructure.Repositories;
using Microsoft.EntityFrameworkCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<BibliotecaContext>(options => options.UseSqlServer
                                                (builder.Configuration.GetConnectionString("BibliotecaContext")));



//builder.Services.AddTransient<IestadoPrestamo, EstadoprestamoRepositories>();
builder.Services.AddTransient<IprestamosRepository, PresatamoRepositories>();
builder.Services.AddTransient<IPrestamoService, PrestamoService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();


