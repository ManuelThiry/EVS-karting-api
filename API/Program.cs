using Repositories;
using Repositories.Queries;
using Repositories.Extensions;
using Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using DotNetEnv;
using Npgsql.EntityFrameworkCore.PostgreSQL;


Env.Load();


var environment = Env.GetString("ASPNETCORE_ENVIRONMENT") ?? Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production";

var builder = WebApplication.CreateBuilder(new WebApplicationOptions
{
    Args = args,
    EnvironmentName = environment
});

var allowedOrigin = Env.GetString("ALLOWED_ORIGIN") ?? "http://localhost:5173";

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy => policy.WithOrigins(allowedOrigin)
                        .AllowAnyHeader()
                        .AllowAnyMethod());
});

builder.Services.AddScoped(sp => new RaceQueries(sp.GetRequiredService<AppDbContext>()));
builder.Services.AddScoped<RaceService>();
builder.Services.AddScoped(sp => new TrackQueries(sp.GetRequiredService<AppDbContext>()));
builder.Services.AddScoped<TrackService>();

builder.Services.AddScoped(sp => new DriverQueries(sp.GetRequiredService<AppDbContext>()));

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

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Karting API", Version = "v1" });
});

var app = builder.Build();

// Ensure database is created and migrations are applied
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    try
    {
        dbContext.Database.Migrate();
        
        // Reset PostgreSQL sequences after migrations
        dbContext.ResetPostgreSqlSequences();
        
        Console.WriteLine("Database migrations applied and sequences reset successfully.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error during database initialization: {ex.Message}");
    }
}

app.UseCors("AllowFrontend");

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();
