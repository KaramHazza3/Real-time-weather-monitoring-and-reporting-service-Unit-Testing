using WeatherMonitoringAndReporting.Common;
using WeatherMonitoringAndReporting.Common.Parsers.Helpers;
using WeatherMonitoringAndReporting.Configuration.Exceptions;

namespace WeatherMonitoringAndReporting.Configuration;

public class ConfigurationReader<T> where T : class
{
    private readonly IParserHelper _parserHelper;
    public ConfigurationReader(IParserHelper parserHelper)
    {
        _parserHelper = parserHelper;
    }
    public T Read(string fileName)
    {
        var configurationPath = PathHelper.GetFullPath(fileName);
        var configuration = File.ReadAllText(configurationPath);
        var parser = _parserHelper.GetParser<T>(configuration);
        if (parser == null)
        {
            throw new NotSupportedConfigurationFileException();
        }
        return parser.Parse(configuration);
    }
    
}