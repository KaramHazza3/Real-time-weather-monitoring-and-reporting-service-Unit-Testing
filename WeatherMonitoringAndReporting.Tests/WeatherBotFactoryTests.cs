using Moq;
using WeatherMonitoringAndReporting.Configuration;
using WeatherMonitoringAndReporting.Features.WeatherBots.Factory;
using WeatherMonitoringAndReporting.Features.WeatherBots.Models.Enums;
using WeatherMonitoringAndReporting.Features.WeatherBots.Strategies;
using WeatherMonitoringAndReporting.Features.WeatherBots.Strategies.Factory;

namespace WeatherMonitoringAndReporting.Tests;

public class WeatherBotFactoryTests
{
    
    [Fact]
    public void GetBots_WhenConfigurationNotEmpty_ShouldCreateTheExpectedNumberOfBots()
    {
        // Arrange
        var mockConfig = TestConfig.BotConfigurations;
        var rainStrategyFactoryMock = new Mock<IBotStrategyFactory>();
        rainStrategyFactoryMock.Setup(x => x.BotType).Returns(BotType.RainBot);
        rainStrategyFactoryMock.Setup(x => x.Create(It.IsAny<BotConfiguration>()))
            .Returns(new RainBotStrategy(nameof(BotType.RainBot), mockConfig[BotType.RainBot].Message, 70));
        var snowStrategyFactoryMock = new Mock<IBotStrategyFactory>();
        snowStrategyFactoryMock.Setup(x => x.BotType).Returns(BotType.SnowBot);
        snowStrategyFactoryMock.Setup(x => x.Create(It.IsAny<BotConfiguration>()))
            .Returns(new RainBotStrategy(nameof(BotType.SnowBot), mockConfig[BotType.SnowBot].Message, 0));
        var sunStrategyFactoryMock = new Mock<IBotStrategyFactory>();
        sunStrategyFactoryMock.Setup(x => x.BotType).Returns(BotType.SunBot);
        sunStrategyFactoryMock.Setup(x => x.Create(It.IsAny<BotConfiguration>()))
            .Returns(new SunBotStrategy(nameof(BotType.SunBot), mockConfig[BotType.SunBot].Message, 0));
        var botStrategyFactories = new List<IBotStrategyFactory>() { rainStrategyFactoryMock.Object, sunStrategyFactoryMock.Object, snowStrategyFactoryMock.Object };
        var sut = new BotFactory(mockConfig, botStrategyFactories);
        
        // Act
        var bots = sut.GetBots();
        
        // Assert
        Assert.Equal(3, bots.Count);
    }

    [Fact]
    public void GetBots_WhenConfigurationEmpty_ShouldSkipCreatingBots()
    {
        // Arrange
        var config = new Dictionary<BotType, BotConfiguration>();
        var botStrategiesFactories = new List<IBotStrategyFactory>();
        var sut = new BotFactory(config, botStrategiesFactories);
        
        // Act
        var bots = sut.GetBots();

        // Assert
        Assert.Empty(bots);
    }
    
    [Fact]
    public void GetBots_WhenFactoryReturnsNull_ShouldSkipCreatingBot()
    {
        // Arrange
        var config = TestConfig.BotConfigurations;

        var factoryMock = new Mock<IBotStrategyFactory>();
        factoryMock.Setup(x => x.BotType).Returns(BotType.RainBot);
        factoryMock.Setup(x => x.Create(It.IsAny<BotConfiguration>())).Returns((BotStrategy?)null);

        var sut = new BotFactory(config, new List<IBotStrategyFactory> { factoryMock.Object });

        // Act
        var bots = sut.GetBots();

        // Assert
        Assert.Empty(bots);
    }
    
}