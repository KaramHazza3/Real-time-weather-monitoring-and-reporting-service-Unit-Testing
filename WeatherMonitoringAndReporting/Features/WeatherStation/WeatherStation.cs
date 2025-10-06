using WeatherMonitoringAndReporting.Common.Parsers;
using WeatherMonitoringAndReporting.Common.Parsers.Exceptions;
using WeatherMonitoringAndReporting.Common.Parsers.Helpers;
using WeatherMonitoringAndReporting.Features.WeatherStation.Events;
using WeatherMonitoringAndReporting.Features.WeatherStation.Models;
using WeatherMonitoringAndReporting.Features.WeatherStation.Providers;

namespace WeatherMonitoringAndReporting.Features.WeatherStation;

public class WeatherStation
{
    private readonly IWeatherProvider _weatherProvider;
    private readonly IParserHelper _parserHelper;
    public WeatherStation(IWeatherProvider weatherProvider, IParserHelper parserHelper)
    {
        _weatherProvider = weatherProvider;
        _parserHelper = parserHelper;
    }
    public event EventHandler<WeatherCreatedEventArgs> WeatherCreated;

    public void Start()
    {
        while (true)
        {
            try
            {
                var weatherData = _weatherProvider.GetWeather();
                if (weatherData == null)
                {
                    Console.WriteLine("Invalid input");
                    continue;
                }
                ProcessWeatherCreated(weatherData);
            }
            catch (ParsingException e)
            {
                Console.WriteLine("Invalid input");
                return;
            }
        }
    }

    public void ProcessWeatherCreated(string weatherData)
    {
        var parser = _parserHelper.GetParser<Weather>(weatherData);
        var weather = parser!.Parse(weatherData);
        if (weather != null)
        {
            OnWeatherCreated(new WeatherCreatedEventArgs(weather));
        }
    }
    
    protected virtual void OnWeatherCreated(WeatherCreatedEventArgs e)
    {
        var handler = WeatherCreated;
        handler?.Invoke(this, e);
    }
}