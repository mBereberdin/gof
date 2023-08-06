namespace gof.Creational.AbstractFactory.DTOs.Motif;

/// <summary>
/// ДТО окна для стандарта Motif.
/// </summary>
/// <param name="Colour">Цвет.</param>
/// <param name="Size">Размер.</param>
/// <param name="IsMinimizeButtonEnable">Включена ли кнопка уменьшения окна.</param>
public record MotifWindowDto(string Colour, string Size, bool IsMinimizeButtonEnable)
{
    /// <summary>
    /// Цвет.
    /// </summary>
    public string Colour { get; init; } = Colour;

    /// <summary>
    /// Размер.
    /// </summary>
    public string Size { get; init; } = Size;

    /// <summary>
    /// Включена ли кнопка уменьшения окна.
    /// </summary>
    public bool IsMinimizeButtonEnable { get; init; } = IsMinimizeButtonEnable;
}