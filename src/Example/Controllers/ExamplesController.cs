namespace Example.Controllers;

using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Контроллер примеров.
/// </summary>
[ApiController]
[Route("[controller]")]
public class ExamplesController : ControllerBase
{
    /// <summary>
    /// Получить строку примера.
    /// </summary>
    /// <returns>string - строку примера.</returns>
    /// <response code="200">Когда строка примера была успешно получена.</response>
    [HttpGet]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetExampleStringAsync()
    {
        var exampleString = await Task.Run(() => "example");

        return Ok(exampleString);
    }
}