using PatternMania.NotificationPatterns.CoreProblem.Models;
using HorseBettingNotifications.Core.Data;
using PatternMania.HorseBettingNotificationPatterns.Patterns.Adapter.Interfaces;

namespace PatternMania.HorseBettingNotificationPatterns.Patterns.Adapter.Input;


public class DbBetAdapter : IBetInputAdapter
{
    private readonly HBDbContext _context;

    public DbBetAdapter(HBDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Bet> GetBets()
    {
        return _context.Bets.ToList();
    }
}
