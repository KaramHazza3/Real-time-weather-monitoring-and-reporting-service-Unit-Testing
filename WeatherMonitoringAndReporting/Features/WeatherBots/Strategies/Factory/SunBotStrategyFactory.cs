using WeatherMonitoringAndReporting.Configuration;
using WeatherMonitoringAndReporting.Features.WeatherBots.Models.Enums;

namespace WeatherMonitoringAndReporting.Features.WeatherBots.Strategies.Factory;

public class SunBotStrategyFactory : IBotStrategyFactory
{
    public BotType BotType => BotType.SunBot;
    public BotStrategy? Create(BotConfiguration botConfiguration)
    {
        if (!botConfiguration.IsEnabled) return null;
        return new SunBotStrategy(nameof(BotType.SunBot), botConfiguration.Message,
            botConfiguration.TemperatureThreshold);
    }
}