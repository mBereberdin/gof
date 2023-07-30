namespace Example.Controllers;

using gof.Creational.AbstractFactory.DTOs.Motif;
using gof.Creational.AbstractFactory.DTOs.PM;
using gof.Creational.AbstractFactory.Implementations;
using gof.Creational.AbstractFactory.Services.Interfaces;

using Mapster;

using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Контроллер абстркактной фабрики.
/// </summary>
[ApiController]
[Route("[controller]")]
public class AbstractFactoryController : ControllerBase
{
    /// <inheritdoc cref="IWidgetService"/>
    private readonly IWidgetService _widgetService;

    /// <inheritdoc cref="MotifWidgetFactory"/>
    private readonly MotifWidgetFactory _motifWidgetFactory;

    /// <inheritdoc cref="PmWidgetFactory"/>
    private readonly PmWidgetFactory _pWidgetFactory;

    /// <inheritdoc cref="AbstractFactoryController"/>
    /// <param name="widgetService">Сервис виджетов.</param>
    /// <param name="motifWidgetFactory">Фабрика виджетов Motif.</param>
    /// <param name="pWidgetFactory">Фабрика виджетов PM.</param>
    public AbstractFactoryController(IWidgetService widgetService, MotifWidgetFactory motifWidgetFactory,
        PmWidgetFactory pWidgetFactory)
    {
        _widgetService = widgetService;
        _motifWidgetFactory = motifWidgetFactory;
        _pWidgetFactory = pWidgetFactory;
    }

    /// <summary>
    /// Получить виджет стандарта PM.
    /// </summary>
    /// <param name="cancellationToken">Токен отмены выполнения операции.</param>
    /// <returns>Виджет стандарта PM в формате json.</returns>
    /// <response code="200">Когда виджет был успешно получен.</response>
    [HttpGet("pm")]
    [ProducesResponseType(typeof(PmWidgetDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetPmWidgetAsync(CancellationToken cancellationToken = default)
    {
        var widget = await _widgetService.CreateWidgetAsync(_pWidgetFactory, cancellationToken);
        var widgetDto = widget.Adapt<PmWidgetDto>();

        return Ok(widgetDto);
    }

    /// <summary>
    /// Получить виджет стандарта Motif.
    /// </summary>
    /// <param name="cancellationToken">Токен отмены выполнения операции.</param>
    /// <returns>Виджет стандарта Motif в формате json.</returns>
    /// <response code="200">Когда виджет был успешно получен.</response>
    [HttpGet("motif")]
    [ProducesResponseType(typeof(MotifWidgetDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetMotifWidgetAsync(CancellationToken cancellationToken = default)
    {
        var widget = await _widgetService.CreateWidgetAsync(_motifWidgetFactory, cancellationToken);
        var widgetDto = widget.Adapt<MotifWidgetDto>();

        return Ok(widgetDto);
    }
}