namespace gof.Creational.AbstractFactory.Abstractions;

using gof.Creational.AbstractFactory.Models.Base;

/// <summary>
/// Фабрика виджетов.
/// </summary>
public class WidgetFactory
{
    /// <summary>
    /// Создать полосу прокрутки.
    /// </summary>
    /// <returns>ScrollBar - созданную полосу прокрутки.</returns>
    public virtual ScrollBar CreateScrollBar()
    {
        return new ScrollBar("yellow", "short");
    }

    /// <summary>
    /// Создать окно.
    /// </summary>
    /// <returns>Window - созданное окно.</returns>
    public virtual Window CreateWindow()
    {
        return new Window("yellow", "short");
    }
}