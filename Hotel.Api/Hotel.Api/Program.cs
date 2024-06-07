using Hotel.Application.Contract;
using Hotel.Application.Services;
using Hotel.Infraestructure.Context;
using Hotel.Infraestructure.Interfaces;
using Hotel.Infraestructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// **Agrega el contexto de la base de datos aquí:**
builder.Services.AddDbContext<HotelContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("HotelContext")));


// Repositorios

builder.Services.AddScoped<ICategoryRepository, CategoriaRepository>();

builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

builder.Services.AddScoped<IHabitacionRepository, HabitacionRepository>();

builder.Services.AddScoped<IEstadoHabitacion, EstadoHabitacionRepository>();

// Servicios

builder.Services.AddTransient<ICategoryService, CategoryService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

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
