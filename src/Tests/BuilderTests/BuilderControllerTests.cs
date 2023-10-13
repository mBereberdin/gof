namespace Tests.BuilderTests;

using Example.Controllers;

/// <summary>
/// Тесты для <see cref="BuilderController"/>.
/// </summary>
public class BuilderControllerTests : BaseTest
{
    /// <inheritdoc cref="BuilderControllerTests"/>
    /// <param name="factory">Фабрика проекта Example.</param>
    public BuilderControllerTests(ExampleWebApplicationFactory<Program> factory) : base(factory)
    {
    }

    [Fact]
    public async Task GetStandardMaze_Success()
    {
        //Act
        var response = await Client.GetAsync("maze/standard");

        //Assert
        response.EnsureSuccessStatusCode();
    }

    [Fact]
    public async Task GetCountingMaze_Success()
    {
        //Act
        var response = await Client.GetAsync("maze/counting");

        //Assert
        response.EnsureSuccessStatusCode();
    }
}