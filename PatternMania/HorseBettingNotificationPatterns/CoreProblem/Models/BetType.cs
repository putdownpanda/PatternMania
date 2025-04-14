using PatternMania.NotificationPatterns.CoreProblem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternMania.HorseBettingNotificationPatterns.CoreProblem.Models
{
    public class BetType
    {
        public string Ulid { get; set; } = System.Ulid.NewUlid(DateTime.UtcNow).ToString();
        public string Name { get; set; } = string.Empty; // e.g., Win, Place, Trifecta
        public virtual ICollection<Bet> Bets { get; set; } = new List<Bet>();
    }
}
