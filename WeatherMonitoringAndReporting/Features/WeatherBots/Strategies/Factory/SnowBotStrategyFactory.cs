using WeatherMonitoringAndReporting.Configuration;
using WeatherMonitoringAndReporting.Features.WeatherBots.Models.Enums;

namespace WeatherMonitoringAndReporting.Features.WeatherBots.Strategies.Factory;

public class SnowBotStrategyFactory : IBotStrategyFactory
{
    public BotType BotType => BotType.SnowBot;
    public BotStrategy? Create(BotConfiguration botConfiguration)
    {
        if (!botConfiguration.IsEnabled) return null;
        return new SnowBotStrategy(nameof(BotType.SnowBot), botConfiguration.Message,
            botConfiguration.TemperatureThreshold);
    }
}