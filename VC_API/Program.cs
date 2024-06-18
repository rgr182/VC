using Microsoft.EntityFrameworkCore;
using VC_API.Domain.Services;
using VC_API.Domain.Repositories;
using VC_API.Domain.Context;
using Microsoft.Extensions.FileProviders;
using System.IO;


var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration; // Obtener la configuraci�n

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
builder.Services.AddScoped<IUserService, UsersSevice>();
builder.Services.AddScoped<IUserRepository, UsersRepository>();
builder.Services.AddScoped<IEmailService, EmailService>();


builder.Services.AddCors(options =>
{
    options.AddPolicy("corsapp", builder =>
    {
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});


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

// Configuración para servir archivos estáticos
var imagesPath = @"C:\Users\saulf\OneDrive\Documentos\GitHub\VC-Backend\VC_API\~\Images";
if (!Directory.Exists(imagesPath))
{
    Directory.CreateDirectory(imagesPath);
}
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(imagesPath),
    RequestPath = "/Images"
});





app.Run();



app.UseDirectoryBrowser(); // Esto permite navegar por los directorios