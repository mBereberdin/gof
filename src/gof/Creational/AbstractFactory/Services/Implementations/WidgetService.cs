namespace gof.Creational.AbstractFactory.Services.Implementations;

using gof.Creational.AbstractFactory.Abstractions;
using gof.Creational.AbstractFactory.Models.Base;
using gof.Creational.AbstractFactory.Services.Interfaces;

/// <summary>
/// Сервис виджетов.
/// </summary>
public sealed class WidgetService : IWidgetService
{
    /// <inheritdoc cref="IWidgetService.CreateWidgetAsync"/>
    public async Task<Widget> CreateWidgetAsync(WidgetFactory widgetFactory, CancellationToken cancellationToken)
    {
        return await Task.Run(() =>
        {
            var widgetWindow = widgetFactory.CreateWindow();
            var widgetScrollbar = widgetFactory.CreateScrollBar();
            var widget = new Widget(widgetScrollbar, widgetWindow);
            if (widget is null)
            {
                throw new NullReferenceException("Не удалось создать виджет.");
            }

            return widget;
        }, cancellationToken);
    }
}