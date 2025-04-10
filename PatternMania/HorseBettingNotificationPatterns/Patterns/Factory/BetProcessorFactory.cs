using HorseBettingNotifications.Patterns.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternMania.HorseBettingNotificationPatterns.Patterns.Factory;
public class BetProcessorFactory
{
    public IBetProcessor GetProcessor(string betTypeName)
    {
        return betTypeName.ToLower() switch
        {
            "win" => new WinBetProcessor(),
            "place" => new PlaceBetProcessor(),
            "trifecta" => new TrifectaBetProcessor(),
            "ff" => new FFBetProcessor(),
            _ => throw new NotSupportedException($"Bet type '{betTypeName}' is not supported.")
        };
    }
}
