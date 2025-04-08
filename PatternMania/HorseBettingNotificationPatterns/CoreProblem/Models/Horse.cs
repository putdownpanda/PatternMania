using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternMania.HorseBettingNotificationPatterns.CoreProblem.Models
{
    public class Horse
    {
        public string Ulid { get; set; }
        public string Name { get; set; } = string.Empty;

        public ICollection<Race> Races { get; set; } = new List<Race>();
    }

}
