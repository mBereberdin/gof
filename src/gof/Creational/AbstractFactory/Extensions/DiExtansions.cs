namespace gof.Creational.AbstractFactory.Extensions;

using gof.Creational.AbstractFactory.DTOs.Motif;
using gof.Creational.AbstractFactory.DTOs.PM;
using gof.Creational.AbstractFactory.Implementations;
using gof.Creational.AbstractFactory.Models.Base;
using gof.Creational.AbstractFactory.Services;
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
        ConfigureMapster();
        RegisterFactoriesServices(services);

        services.AddTransient<MotifWidgetFactory>();
        services.AddTransient<PmWidgetFactory>();
        services.AddTransient<WidgetService>();
    }

    /// <summary>
    /// Зарегистрировать сервисы фабрик.
    /// </summary>
    /// <param name="services">Сервисы приложения.</param>
    private static void RegisterFactoriesServices(IServiceCollection services)
    {
        services.AddTransient<IWidgetService, WidgetService>();
    }

    /// <summary>
    /// Настройка мапстера.
    /// </summary>
    private static void ConfigureMapster()
    {
        TypeAdapterConfig<Widget, PmWidgetDto>.NewConfig()
            .Map(destination => destination.WindowDto, source => source.Window.Adapt<PmWindowDto>())
            .Map(destination => destination.ScrollBarDto, source => source.ScrollBar.Adapt<PmScrollBarDto>());

        TypeAdapterConfig<Widget, MotifWidgetDto>.NewConfig()
            .Map(destination => destination.WindowDto, source => source.Window.Adapt<MotifWindowDto>())
            .Map(destination => destination.ScrollBarDto, source => source.ScrollBar.Adapt<MotifScrollBarDto>());
    }
}