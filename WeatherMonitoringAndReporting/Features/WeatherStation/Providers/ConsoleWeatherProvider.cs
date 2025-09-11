using WeatherMonitoringAndReporting.Common.Parsers.Helpers;
using WeatherMonitoringAndReporting.Features.WeatherStation.Models;

namespace WeatherMonitoringAndReporting.Features.WeatherStation.Providers;

public class ConsoleWeatherProvider : IWeatherProvider
{
    public string? GetWeather()
    {
        Console.Write("Enter weather data (JSON or XML): ");
        var weatherData = Console.ReadLine();
        if (weatherData == null)
        {
            Console.WriteLine("Invalid input");
            return null;
        }

        return weatherData;
    }
}