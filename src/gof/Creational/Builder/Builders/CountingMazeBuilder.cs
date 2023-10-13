namespace gof.Creational.Builder.Builders;

using gof.Creational.Builder.Abstractions;
using gof.Creational.Builder.DTOs;

/// <summary>
/// Строитель лабиринта со счетчиком.
/// </summary>
public class CountingMazeBuilder : MazeBuilder
{
    /// <summary>
    /// Колличество комнат.
    /// </summary>
    private int _rooms;

    /// <summary>
    /// Колличество дверей.
    /// </summary>
    private int _doors;

    /// <inheritdoc cref="CountingMazeBuilder"/>
    public CountingMazeBuilder()
    {
        _rooms = 0;
        _doors = 0;
    }

    /// <inheritdoc/>
    public override void BuildRoom(int roomNumber)
    {
        _rooms += 1;
    }

    /// <inheritdoc/>
    public override void BuildDoor(int roomFrom, int roomTo)
    {
        _doors += 1;
    }

    /// <summary>
    /// Получить дто колличества построек.
    /// </summary>
    public MazeCountsDto GetCountsDto()
    {
        var mazeCountsDto = new MazeCountsDto(_rooms, _doors);

        return mazeCountsDto;
    }
}