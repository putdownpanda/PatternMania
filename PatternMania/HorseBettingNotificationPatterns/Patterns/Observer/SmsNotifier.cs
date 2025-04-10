using PatternMania.HorseBettingNotificationPatterns.Patterns.Observer;
using PatternMania.NotificationPatterns.CoreProblem.Models;
using System;

namespace HorseBettingNotifications.Patterns.Observer;

public class SmsNotifier : IBetObserver
{
    public void OnBetPlaced(Bet bet)
    {
        Console.WriteLine($"📱 SMS to {bet.User.Username}: Bet placed on {bet.Runners}");
    }
}
