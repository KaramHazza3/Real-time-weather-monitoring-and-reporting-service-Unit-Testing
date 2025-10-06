using System.Xml;
using System.Xml.Serialization;
using WeatherMonitoringAndReporting.Common.Parsers.Exceptions;

namespace WeatherMonitoringAndReporting.Common.Parsers;

public class XmlParser<T> : IParser<T> where T : class
{
    public T Parse(string input)
    {
        try
        {
            var xmlSerializer = new XmlSerializer(typeof(T));
            using var reader = new StringReader(input);

            var result = xmlSerializer.Deserialize(reader);
            if (result == null)
            {
                throw new ParsingException("XML", new NullReferenceException("Deserialized result was null"));
            }

            return (T)result;
        }
        catch (XmlException e)
        {
            throw new ParsingException("XML", e);
        }
        catch (Exception e)
        {
            Console.WriteLine("Something went wrong!");
            throw new Exception(e.Message);
        }
    }
}