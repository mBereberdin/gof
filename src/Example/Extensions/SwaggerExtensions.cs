namespace Example.Extensions;

using Microsoft.OpenApi.Models;

/// <summary>
/// Расширения swagger.
/// </summary>
public static class SwaggerExtensions
{
    /// <summary>
    /// Добавить и настроить swagger.
    /// </summary>
    /// <param name="app"> Веб приложение используемое для конфигурирования http пайплайна и маршрутов.</param>
    public static void AddAndConfigureSwagger(this WebApplication app)
    {
        //TODO: Console.WriteLine ниже заменить на логгер.
        Console.WriteLine("Инициализация swagger.");

        app.UseSwagger(options =>
        {
            // Фикс прокси nginx.
            options.PreSerializeFilters.Add((openApiDocument, httpRequest) =>
            {
                if (!httpRequest.Headers.ContainsKey("X-Forwarded-Host") ||
                    !httpRequest.Headers.ContainsKey("X-Forwarded-Prefix"))
                {
                    Console.WriteLine("Не удалось найти заголовки запроса: X-Forwarded-Host или X-Forwarded-Prefix");

                    return;
                }

                var servicePrefix = httpRequest.Headers["X-Forwarded-Prefix"];
                var host = httpRequest.Headers["X-Forwarded-Host"];
                var requestScheme = httpRequest.Scheme;
                var serverUrl = $"{requestScheme}://{host}/{servicePrefix}/";

                Console.WriteLine($"servicePrefix: {servicePrefix}");
                Console.WriteLine($"host: {host}");
                Console.WriteLine($"requestScheme: {requestScheme}");
                Console.WriteLine($"serverUrl: {serverUrl}");

                openApiDocument.Servers = new List<OpenApiServer>
                    { new() { Url = serverUrl } };
            });
        });

        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("v1/swagger.json", "v1");

            var isDevelopment = app.Configuration.GetValue<bool>("IsDevelopment");
            var serviceName = app.Configuration.GetValue<string>("ServiceName");
            // Проверка на подключение swagger в продакшене и установка наименования сервиса для корректного проксирования.
            if (!isDevelopment && !string.IsNullOrEmpty(serviceName))
            {
                options.InjectStylesheet($"/{serviceName}/swagger-ui/SwaggerDark.css");
            }
            else
            {
                options.InjectStylesheet("/swagger-ui/SwaggerDark.css");
            }
        });
    }
}