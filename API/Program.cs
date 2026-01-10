using Repositories;
using Repositories.Queries;
using Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using DotNetEnv;
using Npgsql.EntityFrameworkCore.PostgreSQL;


// Load environment variables from .env
Env.Load();


// Get environment from .env or fallback to ASPNETCORE_ENVIRONMENT
var environment = Env.GetString("ASPNETCORE_ENVIRONMENT") ?? Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production";

var builder = WebApplication.CreateBuilder(new WebApplicationOptions
{
    Args = args,
    EnvironmentName = environment
});

// Ajout CORS
var allowedOrigin = Env.GetString("ALLOWED_ORIGIN") ?? "http://localhost:5173";

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy => policy.WithOrigins(allowedOrigin)
                        .AllowAnyHeader()
                        .AllowAnyMethod());
});

// Enregistrement des services métiers
builder.Services.AddScoped(sp => new RaceQueries(sp.GetRequiredService<AppDbContext>()));
builder.Services.AddScoped<RaceService>();
builder.Services.AddScoped(sp => new TrackQueries(sp.GetRequiredService<AppDbContext>()));
builder.Services.AddScoped<TrackService>();

// Database
var dbUrl = Env.GetString("DATABASE_URL");
var dbProvider = Env.GetString("DATABASE_PROVIDER")?.ToLower();

if (dbProvider == "sqlite" || (string.IsNullOrEmpty(dbProvider) && builder.Environment.IsDevelopment()))
{
    builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseSqlite(dbUrl));
}
else if (dbProvider == "mysql")
{
    builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseMySql(dbUrl, ServerVersion.AutoDetect(dbUrl)));
}
else if (dbProvider == "postgresql" || dbProvider == "postgres")
{
    builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseNpgsql(dbUrl));
}
else
{
    throw new Exception($"Unsupported DB provider: {dbProvider}");
}

// Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Karting API", Version = "v1" });
});

var app = builder.Build();


// Utilisation de CORS
app.UseCors("AllowFrontend");

// Swagger toujours exposé
app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();
