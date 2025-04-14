using PatternMania.NotificationPatterns.CoreProblem.Models;

namespace PatternMania.HorseBettingNotificationPatterns.Patterns.Strategy;

public interface INotificationStrategy
{
    void Notify(Bet bet);
}
