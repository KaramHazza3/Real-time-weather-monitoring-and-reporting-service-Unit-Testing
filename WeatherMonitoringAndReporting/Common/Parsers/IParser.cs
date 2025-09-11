namespace WeatherMonitoringAndReporting.Common.Parsers;

public interface IParser<T> where T : class
{
    T? Parse(string input);
}