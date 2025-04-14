using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternMania.HorseBettingNotificationPatterns.CoreProblem.Models
{
    public class Meeting
    {
        public string Ulid { get; set; } = System.Ulid.NewUlid(DateTime.UtcNow).ToString();
        public string Location { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public virtual ICollection<Race> Races { get; set; } = new List<Race>();
    }

}
