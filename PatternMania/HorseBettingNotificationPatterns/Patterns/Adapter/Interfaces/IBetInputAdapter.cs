using PatternMania.NotificationPatterns.CoreProblem.Models;

namespace PatternMania.HorseBettingNotificationPatterns.Patterns.Adapter.Interfaces;

public interface IBetInputAdapter
{
    IEnumerable<Bet> GetBets();
}
