using Microsoft.EntityFrameworkCore;
using PSKM.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//var dbHost = "pgdb";// Environment.GetEnvironmentVariable("DB_HOST");
//var dbName = "pskm";// Environment.GetEnvironmentVariable("DB_NAME");
//var dbPass = "111021";// Environment.GetEnvironmentVariable("DB_PASSWORD");
//var dbUser = "postgres";// Environment.GetEnvironmentVariable("DB_USER") ?? "postgres"; // default PostgreSQL user

var connectionString = builder.Configuration.GetConnectionString("DbConnection")!; // $"Host={dbHost};Database={dbName};Username={dbUser};Password={dbPass};";

builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseNpgsql(connectionString);
}, ServiceLifetime.Transient, ServiceLifetime.Transient);


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
    app.ApplyMigrations();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
