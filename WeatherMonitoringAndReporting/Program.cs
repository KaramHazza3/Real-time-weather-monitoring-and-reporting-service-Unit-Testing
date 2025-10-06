using WeatherMonitoringAndReporting.Common.Parsers.Helpers;
using WeatherMonitoringAndReporting.Configuration;
using WeatherMonitoringAndReporting.Features.WeatherBots.Factory;
using WeatherMonitoringAndReporting.Features.WeatherBots.Models.Enums;
using WeatherMonitoringAndReporting.Features.WeatherBots.Strategies.Factory;
using WeatherMonitoringAndReporting.Features.WeatherStation;
using WeatherMonitoringAndReporting.Features.WeatherStation.Providers;

namespace WeatherMonitoringAndReporting;

class Program
{
    static void Main(string[] args)
    {
        var configurationReader = new ConfigurationReader<Dictionary<BotType, BotConfiguration>>(new ParserHelper());
        var botConfigurations = configurationReader.Read("appsettings.json");
        var strategyFactories = new List<IBotStrategyFactory>
        {
             new RainBotStrategyFactory(),
             new SunBotStrategyFactory(),
             new SnowBotStrategyFactory() 
        };
        var botFactory = new BotFactory(botConfigurations, strategyFactories);
        var activatedBots = botFactory.GetBots();
        var weatherStation = new WeatherStation(new ConsoleWeatherProvider(), new ParserHelper());
        foreach (var bot in activatedBots)
        {
            weatherStation.WeatherCreated += bot.OnWeatherCreated!;
        }
        weatherStation.Start();
    }
}