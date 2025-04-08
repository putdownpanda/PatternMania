using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternMania.HorseBettingNotificationPatterns.CoreProblem.Models
{
    public class Race
    {
        public string Ulid { get; set; }
        public string MeetingUlid { get; set; }
        public Meeting Meeting { get; set; } = default!;

        public string Name { get; set; } = string.Empty;
        public DateTime StartTime { get; set; }

        public ICollection<Horse> Horses { get; set; } = new List<Horse>();
    }

}
