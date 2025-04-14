using HorseBettingNotifications.Core.Data;
using HorseBettingNotifications.Patterns.Factory;
using Microsoft.EntityFrameworkCore;
using PatternMania.NotificationPatterns.CoreProblem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternMania.HorseBettingNotificationPatterns.Patterns.Factory;
public abstract class BaseBetProcessor : IBetProcessor
{
    protected readonly IDbContextFactory<HBDbContext> _contextFactory;

    public BaseBetProcessor()
    {
        _contextFactory = new HBDbContextFactory();
    }

    protected virtual int MinRunners => 1;
    protected virtual int MaxRunners => 1;
    protected virtual int NoRaces => 1;

    public virtual bool IsValid(Bet bet)
    {
        //Check Required Feilds
        if (string.IsNullOrEmpty(bet.Ulid) ||
            string.IsNullOrEmpty(bet.UserUlid) ||
            string.IsNullOrEmpty(bet.Races) ||
            string.IsNullOrEmpty(bet.BetTypeUlid) ||
            string.IsNullOrEmpty(bet.Runners))
        {
            Log("Bet is missing required fields.");
            return false;
        }

        //Check Bet Type
        var runners  = bet.Runners.Split('|');

        if (MinRunners < runners.Length 
            || runners.Length > MaxRunners)
        {
            Log($"Bet has {runners.Length} runners, but must be between {MinRunners} and {MaxRunners}.");
        }

        var races = bet.Races.Split('|');

        if (NoRaces < races.Length)
        {
            Log($"Bet has {races.Length} races, but must be {NoRaces}.");
        }
        return true;
    }

    public abstract Bet Process(Bet bet);

    protected void Log(string message)
    {
        Console.WriteLine($"[BetProcessor] {message}");
    }

    protected void CommitBet(Bet bet)
    {
        using var context = _contextFactory.CreateDbContext();

        context.Bets.Add(bet);
        context.SaveChanges();

        Console.WriteLine($"bet {bet.Ulid} written to db");
    }
}
