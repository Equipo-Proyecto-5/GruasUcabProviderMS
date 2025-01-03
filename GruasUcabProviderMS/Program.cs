
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


// Obtener y mostrar solo las variables relacionadas con la base de datos
Console.WriteLine("Variables de entorno relacionadas con la base de datos:");

// Acceder a la variable de conexi�n de la base de datos
var dbConnectionString = builder.Configuration.GetConnectionString("DBConnectionString");
Console.WriteLine($"DBConnectionString: {dbConnectionString}");

// Si la cadena de conexi�n se guarda como una variable de entorno,
// tambi�n puedes acceder a ella de esta manera:
var dbConnectionStringFromEnv = Environment.GetEnvironmentVariable("DBConnectionString");
if (!string.IsNullOrEmpty(dbConnectionStringFromEnv))
{
    Console.WriteLine($"DBConnectionString desde la variable de entorno: {dbConnectionStringFromEnv}");
}

// Configuraci�n expl�cita de URLs
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
//var dbConnectionString = builder.Configuration.GetConnectionString("DBConnectionString");
builder.Services.AddDbContext<ProviderDbContext>(options =>
    options.UseNpgsql(dbConnectionString));
builder.Services.AddAutoMapper(typeof(EntryProveedorMapper));



builder.Services.AddScoped<IProveedorRepository, ProveedorRepository>();
builder.Services.AddMediatR(typeof(CreateProveedorCommand).Assembly);





builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", policy =>
    {
        policy.WithOrigins("http://localhost:5173") // Solo permite solicitudes desde este origen
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});




var app = builder.Build();
app.UseCors("AllowSpecificOrigin");



// Aplicar migraciones autom�ticamente al inicio
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ProviderDbContext>();
    try
    {
        dbContext.Database.Migrate();
        Console.WriteLine("Migraciones aplicadas con �xito.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error al aplicar las migraciones: {ex.Message}");
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseAuthorization();

app.MapControllers();

app.Run();
