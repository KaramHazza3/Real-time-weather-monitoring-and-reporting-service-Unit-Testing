using WeatherMonitoringAndReporting.Features.WeatherBots.Models;

namespace WeatherMonitoringAndReporting.Features.WeatherBots.Factory;

public interface IBotFactory
{
    List<Bot> GetBots();
}