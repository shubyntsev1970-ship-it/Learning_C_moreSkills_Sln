/*
 * Создается объект builder. Он нужен для начальной настройки приложения.
    
    Через него настраивают:

    сервисы;
    конфигурацию;
    окружение;
    логирование;
    сервер;
    dependency injection.
*/

using static System.Runtime.InteropServices.JavaScript.JSType;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//  DI - контейнер — это место, куда регистрируются классы/сервисы, 
//  которые потом приложение может автоматически создавать и передавать туда, где они нужны.

// Эта строка добавляет поддержку OpenAPI.
// OpenAPI — это описание твоего API в машинно-читаемом формате.
// Это штука, которая помогает описать, какие endpoint'ы есть в твоем API, какие параметры они принимают и что возвращают.
builder.Services.AddOpenApi();

// До этой строки мы настраивали приложение.
// После этой строки приложение уже собрано.
// builder.Build() создает объект WebApplication.
// Теперь через app мы настраиваем, как приложение будет обрабатывать запросы.
var app = builder.Build();

// Configure the HTTP request pipeline.
// Pipeline — это цепочка обработки HTTP-запроса.

if (app.Environment.IsDevelopment()) // проверяет, запущен ли проект в режиме разработки.
{
    // В режиме Development включают инструменты для разработчика.
    // создается endpoint для OpenAPI-документа.
    // То есть приложение может отдать описание API.
    // Важно: это доступно только в режиме разработки.
    app.MapOpenApi();
}

// Эта middleware перенаправляет HTTP-запросы на HTTPS.
// То есть она говорит:
// Используй защищенный HTTPS, а не обычный HTTP.
app.UseHttpsRedirection();

// Этот массив нужен, чтобы потом случайно выбрать описание погоды.
var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};


// Это регистрация HTTP GET endpoint'а "GetWeatherForecast".
// То есть когда клиент делает запрос: GET / weatherforecast
// выполняется эта функция:
app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5)   // Создает последовательность чисел:
                                            // 1, 2, 3, 4, 5
                                            // Первый аргумент — с какого числа начать.
                                            // Второй аргумент — сколько чисел создать.

        .Select(index =>    // Берет каждый элемент и превращает его во что - то другое.
                            // Было:
                            // 1, 2, 3, 4, 5
                            // Станет:
                            // WeatherForecast, WeatherForecast, WeatherForecast, WeatherForecast, WeatherForecast
                            // index — это текущее число из последовательности.
        new WeatherForecast // Здесь создается объект типа WeatherForecast.
                            //        У него есть 3 основных свойства:
                            // Date
                            // TemperatureC
                            // Summary
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)), // В текущую дата и время добавляет index дней
                                                                // Преобразует DateTime в DateOnly. Например:
                                                                // 07.05.2026 02:15:30   в   07.05.2026
            Random.Shared.Next(-20, 55),                        // Генерирует случайное целое число от -20 до 54
            summaries[Random.Shared.Next(summaries.Length)]     // Здесь выбирается случайный элемент из массива summaries.
                                                                // Диапазон от 0 до summaries.Length-1 
        ))
        .ToArray();     // Преобразует результат в массив.
    return forecast;    // Endpoint возвращает массив объектов.
                        // ASP.NET Core автоматически превращает (сериализирует) этот массив в JSON.
})
.WithName("GetWeatherForecast");    // Это задает endpoint'у имя.
                                    // Имя может использоваться для:
                                    // OpenAPI;
                                    // генерации ссылок;
                                    // документации;
                                    // внутренней идентификации маршрута.
                                    // Сам URL от этого не меняется. URL остается: /weatherforecast

// Это регистрация HTTP GET endpoint'а "GetWeatherForecast1".
// То есть когда клиент делает запрос: GET / weatherforecast1
// выполняется эта функция:
app.MapGet("/weatherforecast1", () => GetWeatherForecast())
.WithName("GetWeatherForecast1");

WeatherForecast[] GetWeatherForecast()
{
    var forecast = Enumerable.Range(1, 2).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
}

// Это регистрация HTTP GET endpoint'а "GetWeatherForecast2".
// То есть когда клиент делает запрос: GET / weatherforecast2
// выполняется эта функция:
app.MapGet("/weatherforecast2", () =>
{
    var users = new[]
    {
        new
        {
            Name = "Alex",
            Age = 25
        },

        new
        {
            Name = "John",
            Age = 30
        },

        new
        {   
            Name = "Kate",
            Age = 22
        }
    };

    return users;

})
.WithName("GetWeatherForecast2");

// Это регистрация HTTP GET endpoint'а "GetWeatherForecast3".
// То есть когда клиент делает запрос: GET / weatherforecast3
// выполняется эта функция:
app.MapGet("/weatherforecast3", () =>
{
    return "OK";
})
.WithName("GetWeatherForecast3");

app.Run();  // Запускаетcя веб-сервер.
            // После этой строки приложение начинает слушать запросы.

// Это объявление типа данных.
// record похож на class, но чаще используется для хранения данных.
// Создает тип с тремя свойствами:
//  Date — дата
//  TemperatureC — температура в Цельсиях
//  Summary — описание
// а также есть вычисляемое свойство TemperatureF
// Это свойство не хранится отдельно.
// Оно вычисляется каждый раз на основе TemperatureC.
internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}

// Алгоритм работы
/*
Program.cs
   ↓
создает builder
   ↓
регистрирует сервисы
   ↓
создает app
   ↓
настраивает middleware
   ↓
регистрирует endpoint GET /weatherforecast
   ↓
app.Run() запускает сервер
   ↓
клиент отправляет GET-запрос
   ↓
выполняется лямбда в MapGet
   ↓
создаются 5 объектов WeatherForecast
   ↓
они превращаются в JSON
   ↓
JSON возвращается клиенту
 
ИЛИ так 

1. Браузер отправляет HTTP GET запрос.
2. ASP.NET Core принимает запрос.
3. Pipeline проверяет middleware.
4. UseHttpsRedirection проверяет HTTPS.
5. Routing ищет подходящий endpoint.
6. Находит MapGet("/weatherforecast", ...).
7. Выполняет лямбду.
8. Создает массив из 5 WeatherForecast.
9. ASP.NET Core сериализует массив в JSON.
10. Браузер получает JSON.
 */