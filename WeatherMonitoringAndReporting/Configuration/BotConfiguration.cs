using System.Text.Json.Serialization;

namespace WeatherMonitoringAndReporting.Configuration;

public record BotConfiguration(
    [property: JsonPropertyName("Enabled")] bool IsEnabled,
    decimal TemperatureThreshold, 
    decimal HumidityThreshold, 
    string Message);