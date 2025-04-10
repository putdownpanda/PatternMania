using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternMania.HorseBettingNotificationPatterns.CoreProblem.Models
{
    public class Runner
    {
        public string Ulid { get; set; } = System.Ulid.NewUlid(DateTime.UtcNow).ToString();
        public int Number { get; set; } = 0;
        public int finishPos { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
        public string Jockey { get; set; } = string.Empty;
        public string Trainer { get; set; } = string.Empty;
        public string RaceUlid { get; set; }
        public Race Race { get; set; }
    }

}
