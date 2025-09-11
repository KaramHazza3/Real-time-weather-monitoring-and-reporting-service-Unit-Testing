using WeatherMonitoringAndReporting.Features.WeatherStation.Models;

namespace WeatherMonitoringAndReporting.Features.WeatherStation.Events;

public class WeatherCreatedEventArgs : EventArgs
{
    public Weather Weather { get; }
    public WeatherCreatedEventArgs(Weather weather) => Weather = weather;
}