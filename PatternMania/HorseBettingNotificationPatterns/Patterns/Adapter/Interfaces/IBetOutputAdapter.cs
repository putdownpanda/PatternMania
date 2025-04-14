using PatternMania.NotificationPatterns.CoreProblem.Models;

namespace PatternMania.HorseBettingNotificationPatterns.Patterns.Adapter.Interfaces;
public interface IBetOutputAdapter
{
    void WriteBet(Bet bet);
}
