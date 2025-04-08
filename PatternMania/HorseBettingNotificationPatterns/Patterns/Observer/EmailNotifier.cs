using PatternMania.NotificationPatterns.CoreProblem.Models;
namespace PatternMania.HorseBettingNotificationPatterns.Patterns.Observer;

public class EmailNotifier : IBetObserver
{
    public void OnBetPlaced(Bet bet)
    {
        Console.WriteLine($"📧 Email sent to {bet.User.Username}: You placed a bet on {bet.Horse.Name}");
    }
}
