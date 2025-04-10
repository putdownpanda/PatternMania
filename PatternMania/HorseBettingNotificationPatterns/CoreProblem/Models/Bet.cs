using PatternMania.HorseBettingNotificationPatterns.CoreProblem.Models;
namespace PatternMania.NotificationPatterns.CoreProblem.Models
{
    public class Bet
    {
        public string Ulid { get; set; } = System.Ulid.NewUlid(DateTime.UtcNow).ToString();
        public decimal Amount { get; set; }
        public DateTime PlacedAt { get; set; } = DateTime.UtcNow;

        public string UserUlid { get; set; }
        public User User { get; set; } = default!;
        /// <summary>
        /// This is a comma-separated list of race ULIDs.
        /// </summary>
        public string Races { get; set; }
        /// <summary>
        /// This is a comma-separated list of horse ULIDS.
        /// </summary>
        public string Runners { get; set; }
        public string BetTypeUlid { get; set; }
        public BetType BetType { get; set; } = default!;
    }


}
