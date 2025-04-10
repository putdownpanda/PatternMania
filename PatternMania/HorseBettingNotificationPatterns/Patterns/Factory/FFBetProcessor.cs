using HorseBettingNotifications.Patterns.Factory;
using PatternMania.NotificationPatterns.CoreProblem.Models;

namespace PatternMania.HorseBettingNotificationPatterns.Patterns.Factory;
public class FFBetProcessor : BaseBetProcessor
{
    protected override int MinRunners => 4;

    public override void Process(Bet bet)
    {
        Log("Processing first four bet: Requires top 4 prediction in ANY ORDER.");
    }
}