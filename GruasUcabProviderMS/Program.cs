
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
var applicationAssembly = Assembly.Load("ProviderMS.Application");

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IProviderDbContext, ProviderDbContext>();
var dbConnectionString = builder.Configuration.GetValue<string>("DBConnectionString");
builder.Services.AddDbContext<ProviderDbContext>(options =>
    options.UseNpgsql(dbConnectionString));
builder.Services.AddAutoMapper(typeof(EntryProveedorMapper));



builder.Services.AddScoped<IProveedorRepository, ProveedorRepository>();
builder.Services.AddMediatR(typeof(CreateProveedorCommand).Assembly);








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
