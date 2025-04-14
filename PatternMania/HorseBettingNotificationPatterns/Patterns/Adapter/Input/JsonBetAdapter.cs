using System.Text.Json;
using PatternMania.HorseBettingNotificationPatterns.Patterns.Adapter.Interfaces;
using PatternMania.NotificationPatterns.CoreProblem.Models;

namespace PatternMania.HorseBettingNotificationPatterns.Patterns.Adapter.Input;


public class JsonBetAdapter : IBetInputAdapter
{
    private readonly string _json;

    public JsonBetAdapter(string json)
    {
        _json = json;
    }

    public IEnumerable<Bet> GetBets()
    {
        return JsonSerializer.Deserialize<List<Bet>>(_json) ?? new List<Bet>();
    }
}
