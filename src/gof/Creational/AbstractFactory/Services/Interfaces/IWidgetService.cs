namespace gof.Creational.AbstractFactory.Services.Interfaces;

using gof.Creational.AbstractFactory.Abstractions;
using gof.Creational.AbstractFactory.Models.Base;

/// <summary>
/// Сервис виджетов.
/// </summary>
public interface IWidgetService
{
    /// <summary>
    /// Создать виджет.
    /// </summary>
    /// <param name="widgetFactory">Фабрика виджетов.</param>
    /// <param name="cancellationToken">Токен отмены выполнения операции.</param>
    /// <returns>Widget - созданный виджет.</returns>
    /// <exception cref="NullReferenceException">Когда не удалось создать виджет.</exception>
    public Task<Widget> CreateWidgetAsync(WidgetFactory widgetFactory, CancellationToken cancellationToken);
}