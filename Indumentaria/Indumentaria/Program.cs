using FluentValidation;
using Indumentaria.AutoMappers;
using Indumentaria.DTOs;
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

//Repository
builder.Services.AddKeyedScoped<IRepository<TipoDeProducto>, TipoDeProductoRepository>("TipoDeProductoRepository");

//Mapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

//Entity Framework - Context
builder.Services.AddDbContext<IndumentariaContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("IndumentariaConnection"));
});

//Validator
builder.Services.AddScoped<IValidator<TipoDeProductoInsertDTO>, ValidadorTiposDeProductoInsertDTO>();


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
