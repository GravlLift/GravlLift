using System.Collections.Generic;
using System.Linq;

namespace FantasyFootball
{
    public class SeasonResult
    {
        public Team Team;
        public int Placement;
        public bool? MadePlayoffs
        {
            get
            {
                if(Placement <= 0)
                {
                    return null;
                }

                return Placement <= 6;
            }
        }
        public List<Result> Results = new List<Result>();

        public int Wins
        {
            get
            {
                return Results.Count(r => (r.Team1 == Team && r.Team1Score > r.Team2Score) || (r.Team2 == Team && r.Team2Score > r.Team1Score));
            }
        }
        public int Ties
        {
            get
            {
                return Results.Count(r => r.Team1Score == r.Team2Score);
            }
        }
        public int Losses
        {
            get
            {
                return Results.Count(r => (r.Team1 == Team && r.Team1Score < r.Team2Score) || (r.Team2 == Team && r.Team2Score < r.Team1Score));
            }
        }
        public double PointsFor
        {
            get
            {
                return Results.Where(r => r.Team1 == Team).Sum(r => r.Team1Score) + Results.Where(r => r.Team2 == Team).Sum(r => r.Team2Score);
            }
        }
        public string RecordString
        {
            get
            {
                return $"({Wins}-{Losses}-{Ties})";
            }
        }

        public SeasonResult(Team team)
        {
            Team = team;
        }

        public SeasonResult(Team team, IEnumerable<Result> results) : this(team)
        {
            Results = results.ToList();
        }

        public IEnumerable<Result> GetMatchesVs(Team opponent)
        {
            return Results.Where(r => (r.Team1 == Team && r.Team2 == opponent) || (r.Team2 == Team && r.Team1 == opponent));
        }
    }
}
