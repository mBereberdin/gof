namespace gof.Creational.Builder.Abstractions;

using gof.Creational.Builder.Models;

/// <summary>
/// Строитель лабиринта.
/// </summary>
public abstract class MazeBuilder
{
    /// <summary>
    /// Построить лабиринт.
    /// </summary>
    public virtual void BuildMaze()
    {
    }

    /// <summary>
    /// Построить комнату.
    /// </summary>
    /// <param name="roomNumber">Конкретный номер комнаты.</param>
    public virtual void BuildRoom(int roomNumber)
    {
    }

    /// <summary>
    /// Построить дверь между конкретными комнатами.
    /// </summary>
    /// <param name="roomFrom">Конкретный номер из какой комнаты</param>
    /// <param name="roomTo">Конкретный номер в какую комнату.</param>
    public virtual void BuildDoor(int roomFrom, int roomTo)
    {
    }

    /// <summary>
    /// Получить лабиринт.
    /// </summary>
    /// <returns>Maze - построенный лабиринт.</returns>
    public virtual Maze GetMaze()
    {
        return new Maze();
    }
}