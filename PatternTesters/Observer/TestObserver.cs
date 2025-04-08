
using PatternMania.HorseBettingNotificationPatterns.Patterns.Observer;
using PatternMania.NotificationPatterns.CoreProblem.Models;

public class TestObserver : IBetObserver
{
    public List<Bet> NotifiedBets { get; } = new();

    public void OnBetPlaced(Bet bet)
    {
        NotifiedBets.Add(bet);
    }
}
