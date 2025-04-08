using PatternMania.HorseBettingNotificationPatterns.CoreProblem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternMania.NotificationPatterns.CoreProblem.Models
{
    public class Bet
    {
        public string Ulid { get; set; }
        public decimal Amount { get; set; }
        public DateTime PlacedAt { get; set; } = DateTime.UtcNow;

        public string UserUlid { get; set; }
        public User User { get; set; } = default!;

        public string RaceUlid { get; set; }
        public Race Race { get; set; } = default!;

        public string HorseUlid { get; set; }
        public Horse Horse { get; set; } = default!;

        public string BetTypeUlid { get; set; }
        public BetType BetType { get; set; } = default!;
    }


}
