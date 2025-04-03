using ModelContextProtocol.Server;
using System.ComponentModel;

namespace MCP.Server;

[McpServerToolType]
public static class WeatherTools
{
    private static readonly string[] Summaries = new[]
    {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    [McpServerTool, Description("Get WeatherForecast for a city.")]
    public static IEnumerable<WeatherForecast> GetWeatherForecast([Description("The city to get WeatherForecast for.")] string city)
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)],
            City = city
        }).ToArray();
    }
}
