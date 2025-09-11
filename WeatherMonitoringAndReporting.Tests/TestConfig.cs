using WeatherMonitoringAndReporting.Configuration;
using WeatherMonitoringAndReporting.Features.WeatherBots.Models.Enums;

namespace WeatherMonitoringAndReporting.Tests;

public static class TestConfig
{
    public static Dictionary<BotType, BotConfiguration> BotConfigurations = new()
    {
        {
            BotType.RainBot, new BotConfiguration(true, 0, 70, "Rainy")
        },
        {
            BotType.SnowBot, new BotConfiguration(false, 0, 0, "Snowing")
        },
        {
            BotType.SunBot, new BotConfiguration(true, 0, 0, "Sunny")
        }
    };
    
}