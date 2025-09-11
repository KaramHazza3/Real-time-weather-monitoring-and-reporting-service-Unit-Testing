using WeatherMonitoringAndReporting.Configuration;
using WeatherMonitoringAndReporting.Features.WeatherBots.Models.Enums;

namespace WeatherMonitoringAndReporting.Features.WeatherBots.Strategies.Factory;

public class RainBotStrategyFactory : IBotStrategyFactory
{
    public BotType BotType => BotType.RainBot;
    public BotStrategy? Create(BotConfiguration botConfiguration)
    {
        if (!botConfiguration.IsEnabled) return null;
        return new RainBotStrategy(nameof(BotType.RainBot), botConfiguration.Message,
            botConfiguration.HumidityThreshold);
    }
}