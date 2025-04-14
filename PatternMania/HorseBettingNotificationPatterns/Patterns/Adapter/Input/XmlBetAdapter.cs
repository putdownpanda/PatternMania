using System.Xml.Serialization;
using System.Text;
using PatternMania.NotificationPatterns.CoreProblem.Models;
using PatternMania.HorseBettingNotificationPatterns.Patterns.Adapter.Interfaces;

namespace PatternMania.HorseBettingNotificationPatterns.Patterns.Adapter.Input;
public class XmlBetAdapter : IBetInputAdapter
{
    private readonly string _xml;

    public XmlBetAdapter(string xml)
    {
        _xml = xml;
    }

    public IEnumerable<Bet> GetBets()
    {
        var serializer = new XmlSerializer(typeof(List<Bet>));
        using var reader = new StringReader(_xml);
        return serializer.Deserialize(reader) as List<Bet> ?? new List<Bet>();
    }
}
