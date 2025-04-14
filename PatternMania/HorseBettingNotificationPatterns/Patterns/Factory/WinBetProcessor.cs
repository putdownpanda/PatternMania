using HorseBettingNotifications.Patterns.Factory;
using Microsoft.EntityFrameworkCore.Internal;
using PatternMania.NotificationPatterns.CoreProblem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternMania.HorseBettingNotificationPatterns.Patterns.Factory;
public class WinBetProcessor : BaseBetProcessor
{
    //defaults are valid here
    public override Bet Process(Bet bet)
    {
        Log("Processing WIN bet: Requires top 1 prediction.");

        bet.isProcessed = true;

        CommitBet(bet);

        return bet;
    }
}