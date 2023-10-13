namespace Tests.BuilderTests;

using FluentAssertions;

using gof.Creational.Builder;
using gof.Creational.Builder.Builders;
using gof.Creational.Builder.Models;

using Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Тесты для <see cref="MazeGame"/>.
/// </summary>
public class MazeGameTests : BaseTest
{
    /// <inheritdoc cref="MazeGameTests"/>
    /// <param name="factory">Фабрика проекта Example.</param>
    public MazeGameTests(ExampleWebApplicationFactory<Program> factory) : base(factory)
    {
    }

    [Fact]
    public void MazeGame_CreateMazeWithStandardMazeBuilder_ReturnMazeDtoSuccess()
    {
        //Arrange
        var standardMazeBuilder = Services.GetRequiredService<StandardMazeBuilder>();
        var mazeGame = Services.GetRequiredService<MazeGame>();
        var maze = new Maze();

        //Act
        var mazeFromDirector = mazeGame.CreateMaze(standardMazeBuilder);

        //Assert
        mazeFromDirector.Should().NotBeEquivalentTo(maze);
    }

    [Fact]
    public void MazeGame_CreateMazeWithCountingMazeBuilder_ReturnMazeDtoSuccess()
    {
        //Arrange
        var standardMazeBuilder = Services.GetRequiredService<CountingMazeBuilder>();
        var mazeGame = Services.GetRequiredService<MazeGame>();
        var maze = new Maze();

        //Act
        var mazeFromDirector = mazeGame.CreateMaze(standardMazeBuilder);

        //Assert
        mazeFromDirector.Should().BeEquivalentTo(maze);
    }
}