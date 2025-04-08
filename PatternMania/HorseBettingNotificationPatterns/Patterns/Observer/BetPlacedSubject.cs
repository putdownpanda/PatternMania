using PatternMania.NotificationPatterns.CoreProblem.Models;

namespace PatternMania.HorseBettingNotificationPatterns.Patterns.Observer;

public class BetPlacedSubject
{
    private readonly List<IBetObserver> _observers = new();

    public void Attach(IBetObserver observer) => _observers.Add(observer);
    public void Detach(IBetObserver observer) => _observers.Remove(observer);

    public void Notify(Bet bet)
    {
        foreach (var observer in _observers)
        {
            observer.OnBetPlaced(bet);
        }
    }
}