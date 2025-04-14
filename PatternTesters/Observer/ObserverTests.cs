using HorseBettingNotifications.Core.Data;
using Microsoft.EntityFrameworkCore;
using PatternMania.HorseBettingNotificationPatterns.Patterns.Observer;
using SQLitePCL;

public class ObserverTests
{
    private readonly IDbContextFactory<HBDbContext> _contextFactory;

    public ObserverTests()
    {
        SQLitePCL.Batteries.Init();
        _contextFactory = new HBDbContextFactory();
    }

    [Fact]
    public void All_Attached_Observers_Are_Notified()
    {
        using var context = _contextFactory.CreateDbContext();

        var bet = context.Bets
            .Include(b => b.User)
            .Include(b => b.Runners)
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
        using var context = _contextFactory.CreateDbContext();

        var bet = context.Bets
            .Include(b => b.User)
            .Include(b => b.Runners)
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
