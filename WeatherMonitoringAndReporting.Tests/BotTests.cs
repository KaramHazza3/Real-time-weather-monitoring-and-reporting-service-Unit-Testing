using Moq;
using WeatherMonitoringAndReporting.Features.WeatherBots.Models;
using WeatherMonitoringAndReporting.Features.WeatherBots.Strategies;
using WeatherMonitoringAndReporting.Features.WeatherStation.Events;
using WeatherMonitoringAndReporting.Features.WeatherStation.Models;

namespace WeatherMonitoringAndReporting.Tests;

public class BotTests
{
    private readonly Weather _weather;
    private readonly Mock<IBotStrategy> _botStrategyMock;
        
    public BotTests()
    {
        _botStrategyMock = new Mock<IBotStrategy>();
        _weather =new Weather()
        {
            Location = "TestLocation", Humidity = 100, Temperature = 100
        };
    }
    
    [Fact]
    public void OnWeatherCreated_ShouldSendMessage_WhenStrategyIsActive()
    {
        // Arrange
        _botStrategyMock.Setup(s => s.ShouldActivate(It.IsAny<Weather>())).Returns(true);

        var bot = new Bot(_botStrategyMock.Object);
        var eventArgs = new WeatherCreatedEventArgs(_weather);

        // Act
        bot.OnWeatherCreated(this, eventArgs);

        // Assert
        _botStrategyMock.Verify(s => s.SendMessage(), Times.Once);
    }

    [Fact]
    public void OnWeatherCreated_ShouldNotSendMessage_WhenStrategyIsInactive()
    {
        // Arrange
        _botStrategyMock.Setup(s => s.ShouldActivate(It.IsAny<Weather>())).Returns(false);

        var bot = new Bot(_botStrategyMock.Object);

        var eventArgs = new WeatherCreatedEventArgs(_weather);

        // Act
        bot.OnWeatherCreated(this, eventArgs);

        // Assert
        _botStrategyMock.Verify(s => s.SendMessage(), Times.Never);
    }
}