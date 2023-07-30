namespace gof.Creational.AbstractFactory.DTOs.PM;

/// <summary>
/// ДТО виджета стандарта PM.
/// </summary>
/// <param name="ScrollBarDto">ДТО полосы прокрутки для стандарта PM.</param>
/// <param name="WindowDto">ДТО окна для стандарта PM.</param>
public record PmWidgetDto(PmScrollBarDto ScrollBarDto, PmWindowDto WindowDto)
{
    /// <inheritdoc cref="PmScrollBarDto"/>
    public PmScrollBarDto ScrollBarDto { get; init; } = ScrollBarDto;

    /// <inheritdoc cref="PmWindowDto"/>
    public PmWindowDto WindowDto { get; init; } = WindowDto;
}