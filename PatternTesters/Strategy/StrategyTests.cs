using HorseBettingNotifications.Core.Data;
using HorseBettingNotifications.Patterns.Factory;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Moq;
using PatternMania.HorseBettingNotificationPatterns.CoreProblem.Models;
using PatternMania.HorseBettingNotificationPatterns.Patterns.Strategy;
using PatternMania.NotificationPatterns.CoreProblem.Models;

namespace PatternTesters.Strategy;
public class NotificationContextTests
{
    private readonly IDbContextFactory<HBDbContext> _contextFactory;
    public NotificationContextTests()
    {
        SQLitePCL.Batteries.Init();
        _contextFactory = new HBDbContextFactory();
    }
    [Fact]
    public void Notifies_User_Using_Correct_Strategy()
    {
        // Arrange
        using var context = _contextFactory.CreateDbContext();
        var bet = context.Bets
            .Include(b => b.User)
            .Include(b => b.BetType)
            .First(b => b.User.PreferredChannel.ToLower() == "email");

        var mockStrategy = new TestNotificationStrategy();
        var contextWithMock = new NotificationContextOverride(new Dictionary<string, INotificationStrategy>
        {
            { "email", mockStrategy }
        });

        // Act
        contextWithMock.Notify(bet);

        // Assert
        Assert.True(mockStrategy.WasNotified);
        Assert.Equal(bet.Ulid, mockStrategy.NotifiedBet!.Ulid);
    }

    [Fact]
    public void Throws_Exception_For_Unsupported_Channel()
    {
        var user = new User
        {
            Ulid = "u1",
            Username = "test",
            PreferredChannel = "fax"
        };

        var bet = new Bet
        {
            Ulid = "b1",
            User = user,
            Runners = System.Ulid.NewUlid(DateTime.UtcNow).ToString(),
            BetType = new BetType { Ulid = "win", Name = "Win" },
            Amount = 50
        };

        var context = new NotificationContext();

        Assert.Throws<NotSupportedException>(() => context.Notify(bet));
    }
}
