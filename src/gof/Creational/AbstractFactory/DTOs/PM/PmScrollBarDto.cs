namespace gof.Creational.AbstractFactory.DTOs.PM;

/// <summary>
/// ДТО полосы прокрутки для стандарта PM.
/// </summary>
/// <param name="Colour">Цвет.</param>
/// <param name="Size">Размер.</param>
/// <param name="IsEnable">Включена ли полоса прокрутки.</param>
public record PmScrollBarDto(string Colour, string Size, bool IsEnable)
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
    /// Включена ли полоса прокрутки.
    /// </summary>
    public bool IsEnable { get; init; } = IsEnable;
}