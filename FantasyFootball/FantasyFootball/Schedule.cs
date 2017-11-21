using System.Collections.Generic;
using System.Linq;

namespace FantasyFootball
{
    public class Schedule
    {
        public List<Team> Teams { get; set; }
        public List<Week> Weeks { get; set; }

        public Schedule()
        {
            Weeks = new List<Week>();
        }
    }
}
