namespace WeatherMonitoringAndReporting.Configuration.Exceptions;

public class NotSupportedConfigurationFileException : Exception
{
    public NotSupportedConfigurationFileException()
        : base("This configuration file format is not supported yet") { }

    public NotSupportedConfigurationFileException(string message)
        : base(message) { }
}