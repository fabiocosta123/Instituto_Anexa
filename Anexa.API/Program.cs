using Anexa.API.Middleware;
using Anexa.API.Settings;
using Anexa.Application.Interfaces;
using Anexa.Application.Services;
using Anexa.Application.UseCases.CriarUsuario;
using Anexa.Domain.Interfaces;
using Anexa.Infrastructure.Context;
using Anexa.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Cors
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:3000")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});


// Connection string for the database
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Registrar o DbContext com o Entity Framework Core
builder.Services.AddDbContext<AnexaDbContext>(options =>
    options.UseSqlServer(connectionString));

// Regitrar o repositório de usuários
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

builder.Services.AddScoped<ICursoRepository, CursoRepository>();
builder.Services.AddScoped<IModuloRepository, ModuloRepository>();

// Adicionar Handlers 
builder.Services.AddScoped<CriarUsuarioHandler>();

// Bind JWT Settings
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("Jwt"));
var jwtSettings = builder.Configuration.GetSection("Jwt").Get<JwtSettings>();

// Injetar serviço com a chave segura
builder.Services.AddSingleton(new JwtService(jwtSettings.Secret));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings.Secret)),
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true
        };
    });




// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.WebHost.UseUrls("http://0.0.0.0:80");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowFrontend");

app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<LoginRequisicaoMiddleware>();

// Endpoint de health check para o Render
app.MapGet("/", () => Results.Ok("Anexa.API is alive"));

app.Run();
