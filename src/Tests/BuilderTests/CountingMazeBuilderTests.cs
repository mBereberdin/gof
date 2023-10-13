namespace Tests.BuilderTests;

using FluentAssertions;

using gof.Creational.Builder.Builders;

using Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Тесты для <see cref="CountingMazeBuilder"/>.
/// </summary>
public class CountingMazeBuilderTests : BaseTest
{
    /// <inheritdoc cref="CountingMazeBuilderTests"/>
    /// <param name="factory">Фабрика проекта Example.</param>
    public CountingMazeBuilderTests(ExampleWebApplicationFactory<Program> factory) : base(factory)
    {
    }

    [Fact]
    public void CountingMazeBuilder_GetCountsDtoWithBuiltRoomsAndDoors_ReturnMazeCountsDtoSuccess()
    {
        //Arrange
        var countingMazeBuilder = Services.GetRequiredService<CountingMazeBuilder>();

        var rooms = new List<int> { 1, 2 };
        var doors = new List<KeyValuePair<int, int>> { new(1, 2) };

        countingMazeBuilder.BuildMaze();

        foreach (var room in rooms)
        {
            countingMazeBuilder.BuildRoom(room);
        }

        foreach (var door in doors)
        {
            countingMazeBuilder.BuildDoor(door.Key, door.Value);
        }

        //Act
        var countsDto = countingMazeBuilder.GetCountsDto();

        //Assert
        countsDto.RoomsCount.Should().Be(rooms.Count);
        countsDto.DoorsCount.Should().Be(doors.Count);
    }

    [Fact]
    public void CountingMazeBuilder_GetCountsDtoWithoutBuiltRoomsAndDoors_ReturnMazeCountsDtoSuccess()
    {
        //Arrange
        var countingMazeBuilder = Services.GetRequiredService<CountingMazeBuilder>();

        //Act
        var countsDto = countingMazeBuilder.GetCountsDto();

        //Assert
        countsDto.RoomsCount.Should().Be(0);
        countsDto.DoorsCount.Should().Be(0);
    }
}