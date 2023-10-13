namespace gof.Creational.Builder.DTOs;

/// <summary>
/// ДТО лабиринта.
/// </summary>
/// <param name="Rooms">Комнаты.</param>
/// <param name="Doors">Двери.</param>
public record MazeDto(HashSet<int> Rooms, HashSet<Dictionary<int, int>> Doors)
{
    /// <summary>
    /// Комнаты.
    /// </summary>
    public HashSet<int> Rooms { get; init; } = Rooms;

    /// <summary>
    /// Двери.
    /// </summary>
    public HashSet<Dictionary<int, int>> Doors { get; init; } = Doors;
}