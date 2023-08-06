namespace gof.Creational.AbstractFactory.DTOs.Motif;

/// <summary>
/// ДТО виджета стандарта Motif.
/// </summary>
/// <param name="ScrollBarDto">ДТО полосы прокрутки для стандарта Motif.</param>
/// <param name="WindowDto">ДТО окна для стандарта Motif.</param>
public record MotifWidgetDto(MotifScrollBarDto ScrollBarDto, MotifWindowDto WindowDto)
{
    /// <inheritdoc cref="MotifScrollBarDto"/>
    public MotifScrollBarDto ScrollBarDto { get; init; } = ScrollBarDto;

    /// <inheritdoc cref="MotifWindowDto"/>
    public MotifWindowDto WindowDto { get; init; } = WindowDto;
}