using HorseBettingNotifications.Core.Data;
using PatternMania.HorseBettingNotificationPatterns.Patterns.Adapter.Interfaces;
using PatternMania.NotificationPatterns.CoreProblem.Models;

namespace PatternMania.HorseBettingNotificationPatterns.Patterns.Adapter.Output;
public class DbBetWriter : IBetOutputAdapter
{
    private readonly HBDbContext _context;

    public DbBetWriter(HBDbContext context)
    {
        _context = context;
    }

    public void WriteBet(Bet bet)
    {
        _context.Bets.Add(bet);
        _context.SaveChanges();
    }
}
