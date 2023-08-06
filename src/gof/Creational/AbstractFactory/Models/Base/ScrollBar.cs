namespace gof.Creational.AbstractFactory.Models.Base;

/// <summary>
/// Полоса прокрутки.
/// </summary>
public class ScrollBar
{
    /// <inheritdoc cref="ScrollBar"/>
    /// <param name="colour">Цвет.</param>
    /// <param name="size">Размер.</param>
    public ScrollBar(string colour, string size)
    {
        Colour = colour;
        Size = size;
    }

    /// <summary>
    /// Цвет.
    /// </summary>
    public string Colour { get; set; }

    /// <summary>
    /// Размер.
    /// </summary>
    public string Size { get; set; }
}