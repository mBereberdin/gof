namespace gof.Creational.Builder.Extensions;

using gof.Creational.Builder.Builders;

using Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Расширения для DI.
/// </summary>
public static class DiExtensions
{
    /// <summary>
    /// Добавить строителей.
    /// </summary>
    /// <param name="services">Сервисы приложения.</param>
    public static void AddBuilders(this IServiceCollection services)
    {
        services.AddTransient<CountingMazeBuilder>();
        services.AddTransient<StandardMazeBuilder>();
        services.AddTransient<MazeGame>();
    }
}