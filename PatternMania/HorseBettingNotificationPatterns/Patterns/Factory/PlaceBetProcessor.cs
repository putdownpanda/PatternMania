using HorseBettingNotifications.Patterns.Factory;
using PatternMania.NotificationPatterns.CoreProblem.Models;

namespace PatternMania.HorseBettingNotificationPatterns.Patterns.Factory;
public class PlaceBetProcessor : BaseBetProcessor
{
    //defaults are valid here
    public override void Process(Bet bet)
    {
        Log("Processing Place bet: Requires 1 horse in a top position. depending on number of runners in race, could be top 2, top3, top4 etc");
    }
}
