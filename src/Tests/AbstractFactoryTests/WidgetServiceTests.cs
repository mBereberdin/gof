namespace Tests.AbstractFactoryTests;

using FluentAssertions;

using gof.Creational.AbstractFactory.DTOs.Motif;
using gof.Creational.AbstractFactory.DTOs.PM;
using gof.Creational.AbstractFactory.Implementations;
using gof.Creational.AbstractFactory.Profiles;
using gof.Creational.AbstractFactory.Services.Implementations;
using gof.Creational.AbstractFactory.Services.Interfaces;

using Mapster;

/// <summary>
/// Тесты для <see cref="IWidgetService"/>.
/// </summary>
public class WidgetServiceTests
{
    /// <inheritdoc cref="WidgetService"/>
    private readonly WidgetService _widgetService;

    /// <inheritdoc cref="WidgetServiceTests"/>
    public WidgetServiceTests()
    {
        _widgetService = new WidgetService();
        TypeAdapterConfig.GlobalSettings.Scan(typeof(ProjectRegister).Assembly);
    }

    [Fact]
    public async Task MotifWidgetFactory_CreateWidget_ReturnMotifWidgetDtoSuccess()
    {
        //Arrange
        var motifWidgetFactory = new MotifWidgetFactory();
        var widgetService = _widgetService;

        var motifScrollBar = motifWidgetFactory.CreateScrollBar();
        var motifWindow = motifWidgetFactory.CreateWindow();
        var motifScrollBarDto = motifScrollBar.Adapt<MotifScrollBarDto>();
        var motifWindowDto = motifWindow.Adapt<MotifWindowDto>();

        var motifWidgetDto = new MotifWidgetDto(motifScrollBarDto, motifWindowDto);

        //Act
        var createdWidget = await widgetService.CreateWidgetAsync(motifWidgetFactory, new CancellationToken());
        var castedWidget = createdWidget.Adapt<MotifWidgetDto>();

        //Assert
        castedWidget.Should().Be(motifWidgetDto);
    }

    [Fact]
    public async Task PmWidgetFactory_CreateWidget_ReturnPmWidgetDtoSuccess()
    {
        //Arrange
        var pmfWidgetFactory = new PmWidgetFactory();
        var widgetService = _widgetService;

        var pmScrollBar = pmfWidgetFactory.CreateScrollBar();
        var pmWindow = pmfWidgetFactory.CreateWindow();
        var pmScrollBarDto = pmScrollBar.Adapt<PmScrollBarDto>();
        var pmWindowDto = pmWindow.Adapt<PmWindowDto>();

        var pmWidgetDto = new PmWidgetDto(pmScrollBarDto, pmWindowDto);

        //Act
        var createdWidget = await widgetService.CreateWidgetAsync(pmfWidgetFactory, new CancellationToken());
        var castedWidget = createdWidget.Adapt<PmWidgetDto>();

        //Assert
        castedWidget.Should().Be(pmWidgetDto);
    }
}