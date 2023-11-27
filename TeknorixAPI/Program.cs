using Megalon;
using Microsoft.EntityFrameworkCore;
using TeknorixAPI.Data;
using TeknorixAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IJobService, JobService>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<ILocationService, LocationService>();
builder.Services.AddDbContext<DataContext>(opt => opt.UseSqlServer("Server=.\\SQLExpress;Database=TeknorixDB;Trusted_Connection=true;TrustServerCertificate=true;"));
builder.Services.AddApiVersioning();
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MigrateDatabase();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
