using WeatherMonitoringAndReporting.Configuration;
using WeatherMonitoringAndReporting.Features.WeatherBots.Models.Enums;

namespace WeatherMonitoringAndReporting.Features.WeatherBots.Strategies.Factory;

public interface IBotStrategyFactory
{
    public BotType BotType { get; }
    BotStrategy? Create(BotConfiguration botConfiguration);
}