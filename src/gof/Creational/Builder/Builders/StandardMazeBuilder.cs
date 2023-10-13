namespace gof.Creational.Builder.Builders;

using gof.Creational.Builder.Abstractions;
using gof.Creational.Builder.Models;

/// <summary>
/// Стандартный строитель лабиринта.
/// </summary>
public class StandardMazeBuilder : MazeBuilder
{
    /// <inheritdoc cref="Maze"/>
    private Maze? _maze;

    /// <inheritdoc/>
    public override void BuildMaze()
    {
        _maze = new Maze();
    }

    /// <inheritdoc/>
    public override void BuildRoom(int roomNumber)
    {
        if (_maze is null)
        {
            throw new InvalidOperationException("Невозможно добавить комнату до постройки лабиринта.");
        }

        if (_maze.Rooms.Contains(roomNumber))
        {
            throw new InvalidOperationException("Комната с таким номером уже сущетсвует.");
        }

        _maze.Rooms = _maze.Rooms.Append(roomNumber).ToHashSet();
    }

    /// <inheritdoc/>
    public override void BuildDoor(int roomFrom, int roomTo)
    {
        if (_maze is null)
        {
            throw new InvalidOperationException("Невозможно добавить дверь до постройки лабиринта.");
        }

        if (!_maze.Rooms.Contains(roomFrom) || !_maze.Rooms.Contains(roomTo))
        {
            throw new InvalidOperationException(
                "Невозможно добавить дверь т.к. отсутствует одна из указанных комнат.");
        }

        var doorDict = new Dictionary<int, int> { { roomFrom, roomTo } };

        _maze.Doors = _maze.Doors.Append(doorDict).ToHashSet();
    }

    /// <inheritdoc/>
    public override Maze GetMaze()
    {
        if (_maze is null)
        {
            throw new InvalidOperationException("Невозможно получить лабиринт т.к. он не построен.");
        }

        return _maze;
    }
}