using HorseBettingNotifications.Patterns.Factory;
using PatternMania.NotificationPatterns.CoreProblem.Models;
using Xunit;
using Moq;
using HorseBettingNotifications.Core.Data;
using Microsoft.EntityFrameworkCore;
using PatternMania.HorseBettingNotificationPatterns.Patterns.Factory;
using PatternMania.HorseBettingNotificationPatterns.CoreProblem.Models;

namespace PatternTesters.Factory;
//here i need to write unit tests for my factory pattern
public class FactoryTests
{
    private readonly Mock<IBetProcessor> _betProcessorMock;
    private readonly IDbContextFactory<HBDbContext> _contextFactory;

    public FactoryTests()
    {
        _betProcessorMock = new Mock<IBetProcessor>();
        SQLitePCL.Batteries.Init();
        _contextFactory = new HBDbContextFactory();
    }

    [Fact]
    public void GetProcessorShouldReturnCorrectProcessor()
    {
        var betTypeName = "Win";
        var betProcessorFactory = new BetProcessorFactory();
        // Act
        var processor = betProcessorFactory.GetProcessor(betTypeName);
        // Assert
        Assert.NotNull(processor);
        Assert.IsType<WinBetProcessor>(processor);
    }

    [Fact]
    public void BetShouldBeValidAndProcessed()
    {
        using var context = _contextFactory.CreateDbContext();
        var betType = context.BetTypes.FirstOrDefault(bt => bt.Name == "Win");
        var user = context.Users.FirstOrDefault();
        //the saving context is different to the one in the factory,
        //therefore we cannot assign the betType and user objects as one normally would
        var bet = new Bet
        {
            //BetType = betType,
            BetTypeUlid = betType.Ulid,
            Runners = System.Ulid.NewUlid(DateTime.UtcNow).ToString(),
            Races = System.Ulid.NewUlid(DateTime.UtcNow).ToString(),
            Amount = 100,
            PlacedAt = DateTime.UtcNow,
            //User = user,
            UserUlid = user.Ulid
        };

        BetProcessorFactory bpFactory = new BetProcessorFactory();

        Assert.True(bpFactory.GetProcessor(betType.Name).IsValid(bet));
        Bet processedBet = bpFactory.GetProcessor(betType.Name).Process(bet);

        Assert.True(processedBet.isProcessed);
    }
    [Fact]
    public void ProcessBetShouldCallProcessBetMethod()
    {
        var bet = new Bet
        {
            Runners = System.Ulid.NewUlid(DateTime.UtcNow).ToString(),
            Races = System.Ulid.NewUlid(DateTime.UtcNow).ToString(),
            Amount = 100,
            PlacedAt = DateTime.UtcNow,
        };


        // Act
        _betProcessorMock.Object.Process(bet);

        // Assert
        _betProcessorMock.Verify(bp => bp.Process(It.IsAny<Bet>()), Times.Once);
    }

    [Fact]
    public void ProcessBetShouldThrowExceptionForInvalidBet()
    {
        // Arrange
        var bet = new Bet { /* Initialize bet properties to be invalid */ };

        _betProcessorMock.Setup(bp => bp.Process(It.IsAny<Bet>())).Throws(new InvalidOperationException());

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => _betProcessorMock.Object.Process(bet));
    }
}