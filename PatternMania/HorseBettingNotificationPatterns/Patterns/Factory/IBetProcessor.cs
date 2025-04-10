using PatternMania.NotificationPatterns.CoreProblem.Models;

namespace HorseBettingNotifications.Patterns.Factory;

public interface IBetProcessor
{
    bool IsValid(Bet bet);
    void Process(Bet bet);
}
