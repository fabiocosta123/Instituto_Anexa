using Anexa.Application.UseCases.CriarUsuario;
using Anexa.Domain.Interfaces;
using Anexa.Infrastructure.Context;
using Anexa.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Connection string for the database
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Registrar o DbContext com o Entity Framework Core
builder.Services.AddDbContext<AnexaDbContext>(options =>
    options.UseSqlServer(connectionString));

// Regitrar o repositório de usuários
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

// Adicionar Handlers 
builder.Services.AddScoped<CriarUsuarioHandler>();

// Add services to the container.

builder.Services.AddControllers();
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
