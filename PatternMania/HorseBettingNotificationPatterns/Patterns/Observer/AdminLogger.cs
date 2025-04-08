using PatternMania.HorseBettingNotificationPatterns.Patterns.Observer;
using PatternMania.NotificationPatterns.CoreProblem.Models;
using System;


namespace HorseBettingNotifications.Patterns.Observer;

public class AdminLogger : IBetObserver
{
    public void OnBetPlaced(Bet bet)
    {
        Console.WriteLine($"[ADMIN LOG] {bet.User.Username} placed {bet.Amount:C} on {bet.Horse.Name}");
    }
}
