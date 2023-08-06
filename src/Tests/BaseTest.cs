namespace Tests;

/// <summary>
/// Базовый тест.
/// </summary>
public class BaseTest : IClassFixture<ExampleWebApplicationFactory<Program>>
{
    /// <inheritdoc cref="BaseTest"/>
    /// <param name="factory">Фабрика проекта Example.</param>
    protected BaseTest(ExampleWebApplicationFactory<Program> factory)
    {
        Services = factory.Services;
        Client = factory.CreateClient();
    }

    /// <summary>
    /// Поставщик сервисов.
    /// </summary>
    protected IServiceProvider Services { get; }

    /// <summary>
    /// HTTP клиент.
    /// </summary>
    protected HttpClient Client { get; }
}