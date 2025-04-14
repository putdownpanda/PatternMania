using PatternMania.HorseBettingNotificationPatterns.Patterns.Strategy;
using PatternMania.NotificationPatterns.CoreProblem.Models;

namespace PatternMania.HorseBettingNotificationPatterns.Patterns.Strategy;
public class EmailNotificationStrategy : INotificationStrategy
{
    public void Notify(Bet bet)
    {
        Console.WriteLine($"📧 Email to {bet.User.Username}: You placed a {bet.BetType.Name}.");
    }
}
