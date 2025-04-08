using PatternMania.NotificationPatterns.CoreProblem.Models;
namespace PatternMania.HorseBettingNotificationPatterns.Patterns.Observer;

public interface IBetObserver
{
    void OnBetPlaced(Bet bet);
}