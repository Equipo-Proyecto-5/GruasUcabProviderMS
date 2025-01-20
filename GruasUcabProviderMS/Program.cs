
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using ProviderMS.Core.Database;
using ProviderMS.Infrastructure.Database;
using MediatR;
using ProviderMS.Core.Repositories;
using ProviderMS.Infrastructure.Repositories;
using ProviderMS.Application.Commands;
using Microsoft.Extensions.DependencyInjection;
using UsersMS.Application.Mapper;
using ProviderMS.Application.Validators;

var builder = WebApplication.CreateBuilder(args);



// Acceder a la variable de conexión de la base de datos
var dbConnectionString = builder.Configuration.GetConnectionString("DBConnectionString");
Console.WriteLine($"DBConnectionString: {dbConnectionString}");

// Si la cadena de conexión se guarda como una variable de entorno,
// también puedes acceder a ella de esta manera:
var dbConnectionStringFromEnv = Environment.GetEnvironmentVariable("DBConnectionString");
if (!string.IsNullOrEmpty(dbConnectionStringFromEnv))
{
    Console.WriteLine($"DBConnectionString desde la variable de entorno: {dbConnectionStringFromEnv}");
}

// Configuración explícita de URLs
builder.WebHost.UseUrls("http://+:5039", "https://+:7255");

var applicationAssembly = Assembly.Load("ProviderMS.Application");


builder.WebHost.ConfigureKestrel(options =>
{
   options.ListenAnyIP(5039); // Puerto HTTP
    options.ListenAnyIP(7255); // Puerto HTTPS
});


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IProviderDbContext, ProviderDbContext>();
builder.Services.AddTransient<IGruaRepository, GruaRepository>();
builder.Services.AddDbContext<ProviderDbContext>(options =>
    options.UseNpgsql(dbConnectionString));
builder.Services.AddAutoMapper(typeof(EntryProveedorMapper));



builder.Services.AddScoped<IProveedorRepository, ProveedorRepository>();
builder.Services.AddMediatR(typeof(CreateProveedorCommand).Assembly);





builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", policy =>
   {
        policy.AllowAnyOrigin() // Permite solicitudes desde cualquier origen
              .AllowAnyMethod()
             .AllowAnyHeader();
    });
});




var app = builder.Build();
app.UseCors("AllowSpecificOrigin");


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseAuthorization();

app.MapControllers();

app.Run();
