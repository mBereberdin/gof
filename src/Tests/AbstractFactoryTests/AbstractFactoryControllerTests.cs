namespace Tests.AbstractFactoryTests;

using Example.Controllers;

/// <summary>
/// Тесты для <see cref="AbstractFactoryController"/>.
/// </summary>
public class AbstractFactoryControllerTests : BaseTest
{
    /// <inheritdoc cref="AbstractFactoryControllerTests"/>
    /// <param name="factory">Фабрика проекта Example.</param>
    public AbstractFactoryControllerTests(ExampleWebApplicationFactory<Program> factory) : base(factory)
    {
    }

    [Fact]
    public async Task GetMotifWidget_Success()
    {
        //Act
        var response = await Client.GetAsync("AbstractFactory/motif");

        //Assert
        response.EnsureSuccessStatusCode();
    }

    [Fact]
    public async Task GetPmWidget_Success()
    {
        //Act
        var response = await Client.GetAsync("AbstractFactory/pm");

        //Assert
        response.EnsureSuccessStatusCode();
    }
}