namespace Tests;

using gof.Creational.AbstractFactory.Extensions;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;

/// <summary>
/// Фабрика проекта Example.
/// </summary>
/// <typeparam name="TProgram">Класс Program проекта.</typeparam>
public class ExampleWebApplicationFactory<TProgram> : WebApplicationFactory<TProgram> where TProgram : class
{
    /// <summary>
    /// Конфигурирование хоста.
    /// </summary>
    /// <param name="builder">Строитель приложения.</param>
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services => { services.AddAbstractFactory(); });

        builder.UseEnvironment("Development");
    }
}