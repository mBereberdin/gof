using System.Reflection;

using Example.Extensions;

using gof.Creational.AbstractFactory.Extensions;

using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Gof example api",
        Description = "ASP.NET Core Web API для проверки работы gof."
    });

    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory,
        xmlFilename));
});

builder.Services.AddAbstractFactory();

builder.Services.AddControllers();

var app = builder.Build();
var isUseSwagger = app.Configuration.GetValue<bool>("IsUseSwagger");

app.UseStaticFiles();

if (isUseSwagger)
{
    app.AddAndConfigureSwagger();
}

app.MapControllers();

app.Run();

// Необходимо для интеграционных тестов.

/// <summary>
///  Программа.
/// </summary>
/// <remarks>Входная точка приложения для конфигурирования и запуска системы.</remarks>
public partial class Program
{
}