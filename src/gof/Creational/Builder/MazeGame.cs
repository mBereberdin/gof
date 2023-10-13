namespace gof.Creational.Builder;

using gof.Creational.Builder.Abstractions;
using gof.Creational.Builder.Models;

/// <summary>
/// Игра Лабиринт.
/// </summary>
public class MazeGame
{
    /// <summary>
    /// Создать лабиринт.
    /// </summary>
    /// <param name="builder">Строитель лабиринта.</param>
    /// <returns>Лабиринт.</returns>
    public Maze CreateMaze(MazeBuilder builder)
    {
        builder.BuildMaze();

        builder.BuildRoom(1);
        builder.BuildRoom(2);
        builder.BuildDoor(1, 2);

        var buildedMaze = builder.GetMaze();

        return buildedMaze;
    }
}