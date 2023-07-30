namespace gof.Creational.AbstractFactory.Implementations;

using gof.Creational.AbstractFactory.Abstractions;
using gof.Creational.AbstractFactory.Models.Base;
using gof.Creational.AbstractFactory.Models.PM;

/// <summary>
/// Фабрика виджетов PM.
/// </summary>
public sealed class PmWidgetFactory : WidgetFactory
{
    /// <inheritdoc cref="WidgetFactory.CreateScrollBar" />
    public override ScrollBar CreateScrollBar()
    {
        return new PmScrollBar("white", "big", false);
    }

    /// <inheritdoc cref="WidgetFactory.CreateWindow" />
    public override Window CreateWindow()
    {
        return new PmWindow("Green", "big", false);
    }
}