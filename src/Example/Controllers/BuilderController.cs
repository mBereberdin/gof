namespace Example.Controllers;

using gof.Creational.Builder;
using gof.Creational.Builder.Builders;
using gof.Creational.Builder.DTOs;
using gof.Creational.Builder.Models;

using Mapster;

using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Контроллер для обработки запросов к паттерну Строитель.
/// </summary>
[ApiController]
[Route("maze")]
public class BuilderController : ControllerBase
{
    /// <inheritdoc cref="MazeGame"/>
    private readonly MazeGame _mazeGame;

    /// <inheritdoc cref="StandardMazeBuilder"/>
    private readonly StandardMazeBuilder _standardMazeBuilder;

    /// <inheritdoc cref="CountingMazeBuilder"/>
    private readonly CountingMazeBuilder _countingMazeBuilder;

    /// <inheritdoc cref="BuilderController"/>
    /// <param name="mazeGame">Игра Лабиринт.</param>
    /// <param name="countingMazeBuilder">Строитель лабиринта со счетчиком.</param>
    /// <param name="standardMazeBuilder">Стандартный строитель лабиринта.</param>
    public BuilderController(MazeGame mazeGame, CountingMazeBuilder countingMazeBuilder,
        StandardMazeBuilder standardMazeBuilder)
    {
        _mazeGame = mazeGame;
        _countingMazeBuilder = countingMazeBuilder;
        _standardMazeBuilder = standardMazeBuilder;
    }

    /// <summary>
    /// Получить стандартный лабиринт.
    /// </summary>
    /// <returns>Задача, результатом которой является дто стандартного лабиринта.</returns>
    [HttpGet("standard")]
    public async Task<IActionResult> GetStandardMaze()
    {
        var getMazeTask = Task.Run(() => _mazeGame.CreateMaze(_standardMazeBuilder));

        var maze = await getMazeTask;
        var mazeDto = maze.Adapt<MazeDto>();

        return Ok(mazeDto);
    }

    /// <summary>
    /// Получить подсчитанные значения лабиринта со счетчиком.
    /// </summary>
    /// <returns>Задача, результатом которой является дто подсчетов лабиринта.</returns>
    [HttpGet("counting")]
    public async Task<IActionResult> GetCountingMaze()
    {
        await Task.Run(() => _mazeGame.CreateMaze(_countingMazeBuilder));

        var countsDto = _countingMazeBuilder.GetCountsDto();

        return Ok(countsDto);
    }
}