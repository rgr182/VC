using Microsoft.EntityFrameworkCore;
using VC_API.Domain.Services;
using VC_API.Domain.Repositories;
using VC_API.Domain.Context;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration; // Obtener la configuración

builder.Services.AddCors(o =>
      o.AddPolicy("corsapp", b =>
          b.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register your service
builder.Services.AddScoped<IPetsRepository, PetsRepository>();
builder.Services.AddScoped<IPetsService, PetsService>();

// Register PetDbContext
builder.Services.AddDbContext<PetDbContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("corsapp");

app.UseAuthorization();

app.MapControllers();

app.Run();
