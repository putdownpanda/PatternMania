
using HorseBettingNotifications.Patterns.Factory;
using PatternMania.NotificationPatterns.CoreProblem.Models;

namespace PatternMania.HorseBettingNotificationPatterns.Patterns.Factory;
public class TrifectaBetProcessor : BaseBetProcessor
{
    protected override int MinRunners => 3;
    protected override int MaxRunners => 3;
    public override Bet Process(Bet bet)
    {
        Log("Processing TRIFECTA bet: Requires top 3 prediction.");

        bet.isProcessed = true;

        CommitBet(bet);

        return bet;
    }
}