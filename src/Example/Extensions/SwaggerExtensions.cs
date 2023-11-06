namespace Example.Extensions;

using System.Reflection;

using Example.Exceptions;

using Microsoft.OpenApi.Models;

using Serilog.Core;

/// <summary>
/// Расширения swagger.
/// </summary>
public static class SwaggerExtensions
{
    /// <summary>
    /// Добавить и настроить swagger.
    /// </summary>
    /// <param name="app"> Веб приложение используемое для конфигурирования http пайплайна и маршрутов.</param>
    /// <param name="logger">Логгер.</param>
    public static void AddAndConfigureSwagger(this WebApplication app, Logger logger)
    {
        logger.Information("Добавление и конфигурирование Swagger.");
        var isDevelopment = app.Configuration.GetValue<bool>("IsDevelopment");
        app.UseSwagger(options =>
        {
            if (!isDevelopment)
            {
                // Фикс прокси nginx.
                options.PreSerializeFilters.Add((openApiDocument, httpRequest) =>
                {
                    logger.Information("Добавление фильтра перед сериализацией.");

                    ThrowIfInvalidHeaders(httpRequest.Headers, logger);

                    var servicePrefix = httpRequest.Headers["X-Forwarded-Prefix"];
                    var host = httpRequest.Headers["X-Forwarded-Host"];
                    var requestScheme = httpRequest.Scheme;
                    var serverUrl = $"{requestScheme}://{host}/{servicePrefix}/";

                    logger.Debug(
                        $"Для конфигурирования swagger получено значение заголовка X-Forwarded-Prefix: {servicePrefix}");
                    logger.Debug(
                        $"Для конфигурирования swagger получено значение заголовка X-Forwarded-Host: {host}");
                    logger.Debug($"Для конфигурирования swagger получено значение съемы запроса: {requestScheme}");
                    logger.Debug($"Для конфигурирования swagger сформирован адрес сервера: {serverUrl}");

                    openApiDocument.Servers = new List<OpenApiServer> { new() { Url = serverUrl } };
                });
                logger.Information("Добавлен фильтр перед сериализацией.");
            }
        });
        logger.Information("Swagger добавлен и сконфигурирован.");

        logger.Information("Добавление и конфигурирование Swagger UI.");
        app.UseSwaggerUI(options =>
        {
            const string url = "v1/swagger.json";
            const string name = "v1";
            options.SwaggerEndpoint(url, name);
            logger.Debug("Для Swagger UI добавлена конечная точка с адресом: {0}, и наименованием: {1}.", url, name);

            var serviceName = app.Configuration.GetValue<string>("ServiceName");
            // Проверка на подключение swagger в продакшене и установка наименования сервиса для корректного проксирования.
            var stylesheetPath = !isDevelopment && !string.IsNullOrEmpty(serviceName)
                ? $"/{serviceName}/swagger-ui/SwaggerDark.css"
                : "/swagger-ui/SwaggerDark.css";
            options.InjectStylesheet(stylesheetPath);

            logger.Debug("Для Swagger UI добавлен стиль с адресом: {0}.", stylesheetPath);
        });
        logger.Information("Swagger UI добавлен и сконфигурирован.");
    }

    /// <summary>
    /// Выкинуть исключение если заголовки запроса не валидные.
    /// </summary>
    /// <param name="headers">Заголовки запроса.</param>
    /// <param name="logger">Логгер.</param>
    /// <exception cref="HeadersException">Когда заголовки запроса не валидные.</exception>
    private static void ThrowIfInvalidHeaders(IHeaderDictionary headers, Logger logger)
    {
        logger.Information("Проверка заголовков запроса для добавления Swagger.");
        if (!headers.ContainsKey("X-Forwarded-Host"))
        {
            logger.Error("Не удалось найти заголовок запроса: X-Forwarded-Host. Заголовки запроса: {0}", headers);

            throw new HeadersException("Не удалось найти заголовок запроса: X-Forwarded-Host.");
        }

        if (!headers.ContainsKey("X-Forwarded-Prefix"))
        {
            logger.Error("Не удалось найти заголовок запроса: X-Forwarded-Prefix. Заголовки запроса: {0}", headers);

            throw new HeadersException("Не удалось найти заголовок запроса: X-Forwarded-Prefix.");
        }

        logger.Information("Заголовки запроса для добавления Swagger проверены и являются корректными.");
    }

    /// <summary>
    /// Добавить генерацию swagger.
    /// </summary>
    /// <param name="serviceCollection">Коллекция сервисов приложения.</param>
    /// <param name="logger">Логгер.</param>
    public static void AddSwaggerGeneration(this IServiceCollection serviceCollection, Logger logger)
    {
        logger.Information("Добавление генерации swagger.");
        serviceCollection.AddSwaggerGen(options =>
        {
            logger.Information("Формирование swagger документа.");
            const string swaggerDocName = "v1";
            var openApiInfo = new OpenApiInfo
            {
                Version = "v1",
                Title = "Gof example api",
                Description = "ASP.NET Core Web API для проверки работы gof."
            };
            options.SwaggerDoc(swaggerDocName, openApiInfo);
            logger.Information("Swagger документ сформирован.");
            logger.Debug("Наименование документа: {0}.", openApiInfo.Title);

            var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            logger.Debug("Сформировано наименование xml файла с описанием swagger: {0}", xmlFilename);

            var xmlCommentsFilePath = Path.Combine(AppContext.BaseDirectory, xmlFilename);
            options.IncludeXmlComments(xmlCommentsFilePath);
            logger.Debug("Сформирован путь xml файла с описанием swagger: {0}", xmlCommentsFilePath);
        });
        logger.Information("Генерация swagger добавлена.");
    }
}