namespace gof.Creational.AbstractFactory.Models.Base;

/// <summary>
/// Окно.
/// </summary>
public class Window
{
    /// <inheritdoc cref="Window"/>
    /// <param name="colour">Цвет.</param>
    /// <param name="size">Размер.</param>
    public Window(string colour, string size)
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