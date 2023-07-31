namespace gof.Creational.AbstractFactory.Extensions;

using System.Reflection;

using gof.Creational.AbstractFactory.Implementations;
using gof.Creational.AbstractFactory.Services.Implementations;
using gof.Creational.AbstractFactory.Services.Interfaces;

using Mapster;

using Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Расширения для DI.
/// </summary>
public static class DiExtensions
{
    /// <summary>
    /// Добавить абстрактную фабрику.
    /// </summary>
    /// <param name="services">Сервисы приложения.</param>
    public static void AddAbstractFactory(this IServiceCollection services)
    {
        RegisterFactoriesServices(services);

        var assembly = Assembly.GetEntryAssembly() ?? throw new InvalidOperationException();
        TypeAdapterConfig.GlobalSettings.Scan(assembly);


        services.AddTransient<MotifWidgetFactory>();
        services.AddTransient<PmWidgetFactory>();
    }

    /// <summary>
    /// Зарегистрировать сервисы фабрик.
    /// </summary>
    /// <param name="services">Сервисы приложения.</param>
    private static void RegisterFactoriesServices(IServiceCollection services)
    {
        services.AddTransient<IWidgetService, WidgetService>();
    }
}