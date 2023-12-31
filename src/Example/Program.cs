using System.Reflection;

using gof.Creational.AbstractFactory.Extensions;
using gof.Creational.Builder.Extensions;

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
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

// Подключение абстрактной фабрики.
builder.Services.AddAbstractFactory();
// Подключения строителя.
builder.Services.AddBuilders();

builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseStaticFiles();
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.InjectStylesheet("/swagger-ui/SwaggerDark.css");
        options.RoutePrefix = string.Empty;
    });
}

app.MapControllers();

app.Run();

// Необходимо для интеграционных тестов.

/// <summary>
/// Программа.
/// </summary>
/// <remarks>Входная точка приложения для конфигурирования и запуска системы.</remarks>
public partial class Program
{
}