using Moq;
using WeatherMonitoringAndReporting.Common.Parsers;
using WeatherMonitoringAndReporting.Common.Parsers.Helpers;
using WeatherMonitoringAndReporting.Features.WeatherStation;
using WeatherMonitoringAndReporting.Features.WeatherStation.Events;
using WeatherMonitoringAndReporting.Features.WeatherStation.Models;
using WeatherMonitoringAndReporting.Features.WeatherStation.Providers;

namespace WeatherMonitoringAndReporting.Tests;

public class WeatherStationTests
{
    private readonly Mock<IParser<Weather>> _parserMock;
    private readonly Mock<IParserHelper> _parserHelperMock;
    private readonly WeatherStation _weatherStation;
    private readonly Weather _weather;
    private WeatherCreatedEventArgs? _capturedArgs;

    public WeatherStationTests()
    {
        _weather = new Weather() { Location = "Test Location", Humidity = 70, Temperature = 30 };
        _parserMock = new Mock<IParser<Weather>>();
        _parserHelperMock = new Mock<IParserHelper>();
        _weatherStation = new WeatherStation(null, _parserHelperMock.Object);
        _capturedArgs = null;
        _parserMock.Setup(x => x.Parse(It.IsAny<string>())).Returns(_weather);

    }
    
    [Fact]
    public void Start_ValidJsonInput_RaisesOnWeatherCreatedEvent()
    {
        // Arrange
        var jsonInput = "{\"Location\":\"Test Location\",\"Temperature\":25.0}";
        _parserHelperMock.Setup(x => x.GetParser<Weather>(jsonInput)).Returns(_parserMock.Object);
        _weatherStation.WeatherCreated += (sender, args) => _capturedArgs = args;
        
        // Act
        _weatherStation.ProcessWeatherCreated(jsonInput);
        
        // Assert
        Assert.NotNull(_capturedArgs);
        Assert.Equal(_weather, _capturedArgs.Weather);
    }
    
    [Fact]
    public void Start_InValidJsonInput_DoesNotRaisesOnWeatherCreatedEvent()
    {
        // Arrange
        var invalidInput = "Invalid Input";
        
        _parserMock.Setup(x => x.Parse(It.IsAny<string>())).Returns((Weather?)null);
        _parserHelperMock.Setup(x => x.GetParser<Weather>(invalidInput)).Returns(_parserMock.Object);
        
        _weatherStation.WeatherCreated += (sender, args) => _capturedArgs = args;
        
        // Act
        _weatherStation.ProcessWeatherCreated(invalidInput);
        
        // Assert
        Assert.Null(_capturedArgs);
    }
    
    [Fact]
    public void Start_ValidXmlInput_RaisesOnWeatherCreatedEvent()
    {
        // Arrange
        var xmlInput = "<WeatherData><Location>City Name</Location><Temperature>32</Temperature><Humidity>40</Humidity></WeatherData>";
        _parserHelperMock.Setup(x => x.GetParser<Weather>(xmlInput)).Returns(_parserMock.Object);
        _weatherStation.WeatherCreated += (sender, args) => _capturedArgs = args;
        
        // Act
        _weatherStation.ProcessWeatherCreated(xmlInput);
        
        // Assert
        Assert.NotNull(_capturedArgs);
        Assert.Equal(_weather, _capturedArgs.Weather);
    }
}