using WeatherMonitoringAndReporting.Features.WeatherStation.Models;

namespace WeatherMonitoringAndReporting.Features.WeatherBots.Strategies;

public class RainBotStrategy : BotStrategy
{
    public RainBotStrategy(string name, string message, decimal threshold) : base(name, message, threshold)
    {
    }
    

    public override bool ShouldActivate(Weather weatherData)
    {
        return weatherData.Humidity > Threshold;
    }
}