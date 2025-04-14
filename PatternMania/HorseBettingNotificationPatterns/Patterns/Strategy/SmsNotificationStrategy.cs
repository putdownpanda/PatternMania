using PatternMania.NotificationPatterns.CoreProblem.Models;

namespace PatternMania.HorseBettingNotificationPatterns.Patterns.Strategy;
public class SmsNotificationStrategy : INotificationStrategy
{
    public void Notify(Bet bet)
    {
        Console.WriteLine($"📱 SMS to {bet.User.Username}.");
    }
}