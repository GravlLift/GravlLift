using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FantasyFootball.Data
{
    public class Team
    {
        public int Id { get; set; }
        public String Name { get; set; }
    }

    public class Matchup
    {
        public int Id { get; set; }
        public int WeekNum { get; set; }
        public int Team1Id { get; set; }
        public int Team2Id { get; set; }
    }
    public class ScoreInformation
    {
        public int Id { get; set; }
        public int MatchupId { get; set; }
        public int TeamId { get; set; }
        public double? ProjectedScore { get; set; }
        public double? ActualScore { get; set; }
    }
}
