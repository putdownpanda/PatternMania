using PatternMania.HorseBettingNotificationPatterns.Patterns.Strategy;
using PatternMania.NotificationPatterns.CoreProblem.Models;

namespace PatternTesters.Strategy;

public class TestNotificationStrategy : INotificationStrategy
{
    public bool WasNotified { get; private set; } = false;
    public Bet? NotifiedBet { get; private set; }

    public void Notify(Bet bet)
    {
        WasNotified = true;
        NotifiedBet = bet;
    }
}
