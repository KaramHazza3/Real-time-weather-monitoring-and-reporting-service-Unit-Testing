using System.Xml.Serialization;

namespace WeatherMonitoringAndReporting.Features.WeatherStation.Models;

[XmlRoot("WeatherData")]
public class Weather
{
    public string Location { get; set; } = string.Empty;
    public decimal Temperature { get; set; }
    public decimal Humidity { get; set; }

    public override string ToString()
    {
        return $"Location: {Location}, Temperature: {Temperature}, Humidity: {Humidity}";
    }
}