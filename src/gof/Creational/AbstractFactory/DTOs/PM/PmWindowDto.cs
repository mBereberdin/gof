namespace gof.Creational.AbstractFactory.DTOs.PM;

/// <summary>
/// ДТО окна для стандарта PM.
/// </summary>
/// <param name="Colour">Цвет.</param>
/// <param name="Size">Размер.</param>
/// <param name="IsCloseButtonEnable">Включена ли кнопка закрытия окна.</param>
public record PmWindowDto(string Colour, string Size, bool IsCloseButtonEnable)
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
    /// Включена ли кнопка закрытия окна.
    /// </summary>
    public bool IsCloseButtonEnable { get; init; } = IsCloseButtonEnable;
}