using WeatherMonitoringAndReporting.Features.WeatherStation.Models;

namespace WeatherMonitoringAndReporting.Features.WeatherBots.Strategies;

public abstract class BotStrategy : IBotStrategy
{
    protected readonly string Name;
    protected readonly string Message;
    protected readonly decimal Threshold;

    protected BotStrategy(string name, string message, decimal threshold)
    {
        this.Name = name;
        this.Message = message;
        this.Threshold = threshold;
    }

    public abstract bool ShouldActivate(Weather weatherData);
  
    public void SendMessage()
    {
        Console.WriteLine($"{Name} activated!");
        Console.WriteLine(Message);
    }
}