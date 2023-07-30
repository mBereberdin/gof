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
    /// <exception cref="NotImplementedException">Когда метод не реализован.</exception>
    public virtual ScrollBar CreateScrollBar()
    {
        return new ScrollBar("yellow", "short");
    }

    /// <summary>
    /// Создать окно.
    /// </summary>
    /// <returns>Window - созданное окно.</returns>
    /// <exception cref="NotImplementedException">Когда метод не реализован.</exception>
    public virtual Window CreateWindow()
    {
        return new Window("yellow", "short");
    }
}