namespace Tests.BuilderTests;

using FluentAssertions;

using gof.Creational.Builder.Builders;

using Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Тесты для <see cref="StandardMazeBuilder"/>.
/// </summary>
public class StandardMazeBuilderTests : BaseTest
{
    /// <inheritdoc cref="StandardMazeBuilderTests"/>
    /// <param name="factory">Фабрика проекта Example.</param>
    public StandardMazeBuilderTests(ExampleWebApplicationFactory<Program> factory) : base(factory)
    {
    }

    [Fact]
    public void StandardMazeBuilder_GetMazeAfterBuildingMaze_ReturnMazeSuccess()
    {
        //Arrange
        var standardMazeBuilder = Services.GetRequiredService<StandardMazeBuilder>();
        var rooms = new List<int> { 1, 2 };
        var doors = new List<KeyValuePair<int, int>> { new(1, 2) };

        //Act
        standardMazeBuilder.BuildMaze();

        foreach (var room in rooms)
        {
            standardMazeBuilder.BuildRoom(room);
        }

        foreach (var door in doors)
        {
            standardMazeBuilder.BuildDoor(door.Key, door.Value);
        }

        var builtMaze = standardMazeBuilder.GetMaze();

        //Assert
        builtMaze.Rooms.Count.Should().Be(rooms.Count);
        builtMaze.Doors.Count.Should().Be(doors.Count);
    }

    [Fact]
    public void StandardMazeBuilder_BuildRoomWithoutMaze_ReturnExceptionFail()
    {
        //Arrange
        var standardMazeBuilder = Services.GetRequiredService<StandardMazeBuilder>();

        //Act & Assert
        Assert.Throws<InvalidOperationException>(() => standardMazeBuilder.BuildRoom(1));
    }

    [Fact]
    public void StandardMazeBuilder_BuildRoomDuplicate_ReturnExceptionFail()
    {
        //Arrange
        var standardMazeBuilder = Services.GetRequiredService<StandardMazeBuilder>();
        standardMazeBuilder.BuildMaze();
        standardMazeBuilder.BuildRoom(1);

        //Act & Assert
        Assert.Throws<InvalidOperationException>(() => standardMazeBuilder.BuildRoom(1));
    }

    [Fact]
    public void StandardMazeBuilder_BuildDoorWithoutRooms_ReturnExceptionFail()
    {
        //Arrange
        var standardMazeBuilder = Services.GetRequiredService<StandardMazeBuilder>();
        standardMazeBuilder.BuildMaze();

        //Act & Assert
        Assert.Throws<InvalidOperationException>(() => standardMazeBuilder.BuildDoor(1, 2));
    }

    [Fact]
    public void StandardMazeBuilder_BuildDoorWithoutMaze_ReturnExceptionFail()
    {
        //Arrange
        var standardMazeBuilder = Services.GetRequiredService<StandardMazeBuilder>();

        //Act & Assert
        Assert.Throws<InvalidOperationException>(() => standardMazeBuilder.BuildDoor(1, 2));
    }

    [Fact]
    public void StandardMazeBuilder_GetMazeWithoutMaze_ReturnExceptionFail()
    {
        //Arrange
        var standardMazeBuilder = Services.GetRequiredService<StandardMazeBuilder>();

        //Act & Assert
        Assert.Throws<InvalidOperationException>(() => standardMazeBuilder.GetMaze());
    }
}