using WeatherMonitoringAndReporting.Common.Parsers.Exceptions;

namespace WeatherMonitoringAndReporting.Common.Parsers.Helpers;

public class ParserHelper : IParserHelper
{
    private const string JsonStarter = "{";
    private const string XmlStarter = "<";
    public IParser<T>? GetParser<T>(string input) where T : class
    {
        if (input.TrimStart().StartsWith(XmlStarter))
        {
            return new XmlParser<T>();
        }

        if (input.TrimStart().StartsWith(JsonStarter))
        {
            return new JsonParser<T>();
        }

        throw new ParsingException("This input is not supported yet", new NotSupportedException());
    }
}
