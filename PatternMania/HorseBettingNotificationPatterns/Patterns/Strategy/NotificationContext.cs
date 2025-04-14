using PatternMania.NotificationPatterns.CoreProblem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternMania.HorseBettingNotificationPatterns.Patterns.Strategy;
public class NotificationContext
{
    private readonly Dictionary<string, INotificationStrategy> _strategies;

    public NotificationContext()
    {
        _strategies = new Dictionary<string, INotificationStrategy>(StringComparer.OrdinalIgnoreCase)
        {
            { "email", new EmailNotificationStrategy() },
            { "sms", new SmsNotificationStrategy() },
        };
    }

    public void Notify(Bet bet)
    {
        if (!_strategies.TryGetValue(bet.User.PreferredChannel, out var strategy))
        {
            throw new NotSupportedException($"No strategy defined for {bet.User.PreferredChannel}");
        }

        strategy.Notify(bet);
    }
}

public class NotificationContextOverride : NotificationContext
{
    private readonly Dictionary<string, INotificationStrategy> _overrideStrategies;

    public NotificationContextOverride(Dictionary<string, INotificationStrategy> strategies)
    {
        _overrideStrategies = strategies;
    }

    public new void Notify(Bet bet)
    {
        if (!_overrideStrategies.TryGetValue(bet.User.PreferredChannel.ToLower(), out var strategy))
            throw new NotSupportedException();

        strategy.Notify(bet);
    }
}
