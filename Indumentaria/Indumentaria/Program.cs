using FluentValidation;
using Indumentaria.AutoMappers;
using Indumentaria.DTOs;
using Indumentaria.Incializador;
using Indumentaria.Models;
using Indumentaria.Repository;
using Indumentaria.Services;
using Indumentaria.Validators;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//Service
builder.Services.AddKeyedScoped<ICrud<TipoDeProductoDTO, TipoDeProductoInsertDTO, TipoDeProductoUpdateDTO>, TipoDeProductoService>("TipoDeProductoService");
builder.Services.AddKeyedScoped<ICrud<ProductoDTO, ProductoInsertDTO, ProductoUpdateDTO>, ProductoService>("ProductoService");
builder.Services.AddKeyedScoped<ICrud<MarcaDTO, MarcaInsertDTO, MarcaUpdateDTO>, MarcaService>("MarcaService");
builder.Services.AddKeyedScoped<ICrud<ProveedorDTO, ProveedorInsertDTO, ProveedorUpdateDTO>, ProveedorService>("ProveedorService");


//Repository
builder.Services.AddKeyedScoped<IRepository<TipoDeProducto>, TipoDeProductoRepository>("TipoDeProductoRepository");
builder.Services.AddKeyedScoped<IRepository<Producto>, ProductoRepository>("ProductoRepository");
builder.Services.AddKeyedScoped<IRepository<Marca>, MarcaRepository>("MarcaRepository");
builder.Services.AddKeyedScoped<IRepository<Proveedor>, ProveedorRepository>("ProveedorRepository");

//Mapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

//Entity Framework - Context
builder.Services.AddDbContext<IndumentariaContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("IndumentariaConnection"));
});

//Validator
builder.Services.AddScoped<IValidator<TipoDeProductoInsertDTO>, ValidadorTiposDeProductoInsertDTO>();

//DB produccion
builder.Services.AddScoped<IDBInicializador, DBInicializador>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
