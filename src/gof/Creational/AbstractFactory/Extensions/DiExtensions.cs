namespace gof.Creational.AbstractFactory.Extensions;

using gof.Creational.AbstractFactory.Implementations;
using gof.Creational.AbstractFactory.Profiles;
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
        TypeAdapterConfig.GlobalSettings.Scan(typeof(ProjectRegister).Assembly);
    }

    /// <summary>
    /// Зарегистрировать сервисы фабрик.
    /// </summary>
    /// <param name="services">Сервисы приложения.</param>
    private static void RegisterFactoriesServices(IServiceCollection services)
    {
        services.AddTransient<IWidgetService, WidgetService>();
        services.AddTransient<MotifWidgetFactory>();
        services.AddTransient<PmWidgetFactory>();
    }
}