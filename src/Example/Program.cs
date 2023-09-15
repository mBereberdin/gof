using Example.Extensions;

using gof.Creational.AbstractFactory.Extensions;

using Serilog;

var builder = WebApplication.CreateBuilder(args);

using var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();

var isUseSwagger = builder.Configuration.GetValue<bool>("IsUseSwagger");
if (isUseSwagger)
{
    builder.Services.AddSwaggerGeneration(logger);
}

builder.Services.AddAbstractFactory();

builder.Services.AddControllers();

var app = builder.Build();

app.UseStaticFiles();

if (isUseSwagger)
{
    app.AddAndConfigureSwagger(logger);
}

app.MapControllers();

Log.CloseAndFlush();

app.Run();

// Необходимо для интеграционных тестов.

/// <summary>
///  Программа.
/// </summary>
/// <remarks>Входная точка приложения для конфигурирования и запуска системы.</remarks>
public partial class Program
{
}