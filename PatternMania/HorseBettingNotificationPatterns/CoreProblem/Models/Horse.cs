using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternMania.HorseBettingNotificationPatterns.CoreProblem.Models
{
    public class Horse
    {
        public string Ulid { get; set; } = System.Ulid.NewUlid(DateTime.UtcNow).ToString();
        public string Name { get; set; } = string.Empty;
        public string RaceUlid { get; set; }
        public ICollection<Race> Races { get; set; } = new List<Race>();
    }

}
