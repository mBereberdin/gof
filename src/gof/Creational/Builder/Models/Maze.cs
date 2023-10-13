namespace gof.Creational.Builder.Models;

/// <summary>
/// Лабиринт.
/// </summary>
public class Maze
{
    /// <inheritdoc cref="Maze"/>
    public Maze()
    {
        Rooms = new HashSet<int>();
        Doors = new HashSet<Dictionary<int, int>>();
    }

    /// <summary>
    /// Комнаты.
    /// </summary>
    public HashSet<int> Rooms { get; set; }

    /// <summary>
    /// Двери.
    /// </summary>
    public HashSet<Dictionary<int, int>> Doors { get; set; }
}