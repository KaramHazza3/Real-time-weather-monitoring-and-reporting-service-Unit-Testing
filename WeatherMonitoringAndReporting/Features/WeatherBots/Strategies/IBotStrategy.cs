using WeatherMonitoringAndReporting.Features.WeatherStation.Models;

namespace WeatherMonitoringAndReporting.Features.WeatherBots.Strategies;

public interface IBotStrategy
{
    bool ShouldActivate(Weather weatherData);
    void SendMessage();
}