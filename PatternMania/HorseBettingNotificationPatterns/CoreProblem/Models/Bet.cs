﻿using PatternMania.HorseBettingNotificationPatterns.CoreProblem.Models;
using System.Xml.Serialization;
namespace PatternMania.NotificationPatterns.CoreProblem.Models
{
    public class Bet
    {
        public string Ulid { get; set; } = System.Ulid.NewUlid(DateTime.UtcNow).ToString();
        public decimal Amount { get; set; }
        public DateTime PlacedAt { get; set; } = DateTime.UtcNow;

        public string UserUlid { get; set; }
        [XmlIgnore]
        public User User { get; set; } = default!;
        /// <summary>
        /// This is a comma-separated list of race ULIDs.
        /// </summary>
        public string Races { get; set; }
        /// <summary>
        /// This is a comma-separated list of horse ULIDS.
        /// </summary>
        public string Runners { get; set; }
        public bool isProcessed { get;set; } = false;
        public string BetTypeUlid { get; set; }
        [XmlIgnore]
        public BetType BetType { get; set; }
    }


}
