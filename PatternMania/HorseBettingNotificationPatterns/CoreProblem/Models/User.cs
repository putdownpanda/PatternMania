using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternMania.NotificationPatterns.CoreProblem.Models
{
    public class User
    {
        public string Ulid { get; set; } = System.Ulid.NewUlid(DateTime.UtcNow).ToString();
        public string Username { get; set; } = string.Empty;
        public string PreferredChannel { get; set; } = "Email"; // or "SMS", etc.

        public virtual ICollection<Bet> Bets { get; set; } = new List<Bet>();
    }

}
