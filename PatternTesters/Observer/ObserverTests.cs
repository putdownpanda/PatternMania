using HorseBettingNotifications.Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using PatternMania.HorseBettingNotificationPatterns.Patterns.Observer;
using Xunit;

public class ObserverTests
{
    [Fact]
    public void All_Attached_Observers_Are_Notified()
    {
        var options = new DbContextOptionsBuilder<HBDbContext>()
     .UseSqlite("DataSource=:memory:")
     .Options;

        using var context = new HBDbContext(options);
        context.Database.OpenConnection(); // Required for in-memory SQLite
        context.Database.EnsureCreated();

        var bet = context.Bets
            .Include(b => b.User)
            .Include(b => b.Horse)
            .First();

        var observer1 = new TestObserver();
        var observer2 = new TestObserver();
        var subject = new BetPlacedSubject();
        subject.Attach(observer1);
        subject.Attach(observer2);

        // Act
        subject.Notify(bet);

        // Assert
        Assert.Single(observer1.NotifiedBets);
        Assert.Single(observer2.NotifiedBets);
        Assert.Equal(bet.Ulid, observer1.NotifiedBets[0].Ulid);
        Assert.Equal(bet.Ulid, observer2.NotifiedBets[0].Ulid);
    }

    [Fact]
    public void Detached_Observer_Is_Not_Notified()
    {
        var options = new DbContextOptionsBuilder<HBDbContext>()
    .UseSqlite("DataSource=:memory:")
    .Options;

        using var context = new HBDbContext(options);
        context.Database.OpenConnection(); // Required for in-memory SQLite
        context.Database.EnsureCreated();

        var bet = context.Bets
            .Include(b => b.User)
            .Include(b => b.Horse)
            .First();

        var observer = new TestObserver();
        var subject = new BetPlacedSubject();
        subject.Attach(observer);
        subject.Detach(observer); // detach before notification

        // Act
        subject.Notify(bet);

        // Assert
        Assert.Empty(observer.NotifiedBets);
    }
}
