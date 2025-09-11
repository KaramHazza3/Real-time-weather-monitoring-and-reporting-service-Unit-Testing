using WeatherMonitoringAndReporting.Features.WeatherBots.Strategies;
using WeatherMonitoringAndReporting.Features.WeatherStation.Events;

namespace WeatherMonitoringAndReporting.Features.WeatherBots.Models;

public class Bot
{
    private readonly IBotStrategy _botStrategy;
    public Bot(IBotStrategy botStrategy)
    {
        _botStrategy = botStrategy;
    }
        
    public void OnWeatherCreated(object sender, WeatherCreatedEventArgs e)
    {
        if (!_botStrategy.ShouldActivate(e.Weather)) return;
        _botStrategy.SendMessage();
    }
}