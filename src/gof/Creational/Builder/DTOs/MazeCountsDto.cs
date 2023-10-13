namespace gof.Creational.Builder.DTOs;

/// <summary>
/// ДТО подсчетов лабиринта.
/// </summary>
/// <param name="RoomsCount">Колличество комнат.</param>
/// <param name="DoorsCount">Колличество дверей.</param>
public record MazeCountsDto(int RoomsCount, int DoorsCount)
{
    /// <summary>
    /// Колличество комнат.
    /// </summary>
    public int RoomsCount { get; init; } = RoomsCount;

    /// <summary>
    /// Колличество дверей.
    /// </summary>
    public int DoorsCount { get; init; } = DoorsCount;
}