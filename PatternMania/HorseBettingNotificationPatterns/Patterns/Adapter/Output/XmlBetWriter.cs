using PatternMania.HorseBettingNotificationPatterns.Patterns.Adapter.Interfaces;
using PatternMania.NotificationPatterns.CoreProblem.Models;
using System.Xml.Serialization;

namespace PatternMania.HorseBettingNotificationPatterns.Patterns.Adapter.Output;
public class XmlBetWriter : IBetOutputAdapter
{
    public void WriteBet(Bet bet)
    {
        var serializer = new XmlSerializer(typeof(Bet));
        using var writer = new StringWriter();
        serializer.Serialize(writer, bet);
        Console.WriteLine(writer.ToString());
    }
}
