using System.Text.Json;
using WeatherMonitoringAndReporting.Common.Parsers.Exceptions;

namespace WeatherMonitoringAndReporting.Common.Parsers;

public class JsonParser<T> : IParser<T> where T : class
{
    public T Parse(string input)
    {
        try
        {
            var result = JsonSerializer.Deserialize<T>(input);

            if (result == null)
                throw new ParsingException("JSON", new NullReferenceException("Deserialized result was null"));

            return result;
        }
        catch (JsonException e)
        {
            throw new ParsingException("JSON", e);
        }
        catch (Exception e)
        {
            Console.WriteLine("Something went wrong!");
            throw new ParsingException("JSON", e);
        }
    }
}