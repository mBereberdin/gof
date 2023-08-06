namespace Tests.AbstractFactoryTests;

using FluentAssertions;

using gof.Creational.AbstractFactory.DTOs.Motif;
using gof.Creational.AbstractFactory.DTOs.PM;
using gof.Creational.AbstractFactory.Implementations;
using gof.Creational.AbstractFactory.Services.Interfaces;

using Mapster;

using Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Тесты для <see cref="IWidgetService"/>.
/// </summary>
public class WidgetServiceTests : BaseTest
{
    /// <inheritdoc cref="WidgetServiceTests"/>
    /// <param name="factory">Фабрика проекта Example.</param>
    public WidgetServiceTests(ExampleWebApplicationFactory<Program> factory) : base(factory)
    {
    }

    [Fact]
    public async Task MotifWidgetFactory_CreateWidget_ReturnMotifWidgetDtoSuccess()
    {
        //Arrange
        var motifWidgetFactory = Services.GetRequiredService<MotifWidgetFactory>();
        var widgetService = Services.GetRequiredService<IWidgetService>();

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
        var pmfWidgetFactory = Services.GetRequiredService<PmWidgetFactory>();
        var widgetService = Services.GetRequiredService<IWidgetService>();

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