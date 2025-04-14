using PatternMania.HorseBettingNotificationPatterns.Patterns.Adapter.Interfaces;
using PatternMania.NotificationPatterns.CoreProblem.Models;
using System.Text.Json;
using System.Threading.Tasks;

namespace PatternMania.HorseBettingNotificationPatterns.Patterns.Adapter.Output;
public class JsonBetWriter : IBetOutputAdapter
{
    public void WriteBet(Bet bet)
    {
        string json = JsonSerializer.Serialize(bet, new JsonSerializerOptions { WriteIndented = true });
        Console.WriteLine(json);
    }
}

