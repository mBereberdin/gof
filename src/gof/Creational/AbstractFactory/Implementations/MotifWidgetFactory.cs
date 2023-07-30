namespace gof.Creational.AbstractFactory.Implementations;

using gof.Creational.AbstractFactory.Abstractions;
using gof.Creational.AbstractFactory.Models.Base;
using gof.Creational.AbstractFactory.Models.Motif;

/// <summary>
/// Фабрика виджетов Motif.
/// </summary>
public sealed class MotifWidgetFactory : WidgetFactory
{
    /// <inheritdoc cref="WidgetFactory.CreateScrollBar" />
    public override ScrollBar CreateScrollBar()
    {
        return new MotifScrollBar("black", "small", true);
    }

    /// <inheritdoc cref="WidgetFactory.CreateWindow" />
    public override Window CreateWindow()
    {
        return new MotifWindow("gray", "small", true);
    }
}