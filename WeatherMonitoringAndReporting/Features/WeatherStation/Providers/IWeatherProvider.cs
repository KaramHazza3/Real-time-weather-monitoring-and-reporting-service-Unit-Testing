using WeatherMonitoringAndReporting.Features.WeatherStation.Models;

namespace WeatherMonitoringAndReporting.Features.WeatherStation.Providers;

public interface IWeatherProvider
{
    string? GetWeather();
}