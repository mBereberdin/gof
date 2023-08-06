namespace gof.Creational.AbstractFactory.Models.Base;

/// <summary>
/// Виджет.
/// </summary>
public class Widget
{
    /// <inheritdoc cref="Widget"/>
    /// <param name="scrollBar">Полоса прокрутки.</param>
    /// <param name="window">Окно.</param>
    public Widget(ScrollBar scrollBar, Window window)
    {
        ScrollBar = scrollBar;
        Window = window;
    }

    /// <inheritdoc cref="ScrollBar"/>
    public ScrollBar ScrollBar { get; set; }

    /// <inheritdoc cref="Window"/>
    public Window Window { get; set; }
}