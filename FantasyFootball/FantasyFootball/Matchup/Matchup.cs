using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.DataVisualization.Charting;

namespace FantasyFootball
{

    public class Matchup
    {
        public MatchupTeamInfo Team1ScoreInformation;
        public MatchupTeamInfo Team2ScoreInformation;

        public Matchup(MatchupTeamInfo team1, MatchupTeamInfo team2)
        {
            Team1ScoreInformation = team1;
            Team2ScoreInformation = team2;
        }

        public override string ToString()
        {
            return $"{Team1ScoreInformation.Team} vs {Team2ScoreInformation.Team}";
        }
    }
    
    public class Week
    {
        public int WeekNumber;
        public List<Matchup> Matchups;

        public override string ToString()
        {
            return $"Week {WeekNumber}";
        }
    }
}
