namespace WeatherMonitoringAndReporting.Common.Parsers.Helpers;

public interface IParserHelper
{
    IParser<T>? GetParser<T>(string input) where T : class;
}