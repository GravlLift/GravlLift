using Meta.Numerics.Statistics.Distributions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyFootball
{

    public enum Outcome { None, Win, Loss, Tie }

    class Program
    {
        const int SIMULATIONS = 10000;

        static Data.IFantasyDataProvider provider = new Data.CsvDataProvider();
        static Schedule Schedule;

        static void Main(string[] args)
        {
            Schedule = provider.GetSchedule();

            // Load result data structure
            Dictionary<Team, List<SeasonResult>> SeasonResults = new Dictionary<Team, List<SeasonResult>>();
            foreach (var team in Schedule.Teams)
            {
                SeasonResults.Add(team, new List<SeasonResult>());
            }

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            // Simulate seasons
            for (int i = 0; i < SIMULATIONS; i++)
            {
                //Console.WriteLine($"Simulating season {i + 1}...");
                foreach (var team in Schedule.Teams)
                {
                    SeasonResults[team].Add(new SeasonResult(team));
                }

                foreach (var week in Schedule.Weeks)
                {
                    foreach (Matchup matchup in week.Matchups)
                    {
                        Result result = GetMatchupResult(matchup.Team1ScoreInformation, matchup.Team2ScoreInformation);

                        SeasonResults[matchup.Team1ScoreInformation.Team].Last().Results.Add(result);
                        SeasonResults[matchup.Team2ScoreInformation.Team].Last().Results.Add(result);
                    }
                }

                List<SeasonResult> combinedLastSeasonResults = new List<SeasonResult>();
                foreach (var team in Schedule.Teams)
                {
                    combinedLastSeasonResults.Add(SeasonResults[team].Last());
                }

                List<SeasonResult> rankedLastSeasonResults = combinedLastSeasonResults.OrderByDescending(r => r.Wins).ThenByDescending(r => r.PointsFor).ToList();

                for (int j = 0; j < rankedLastSeasonResults.Count; j++)
                {
                    rankedLastSeasonResults[j].Placement = j + 1;
                }

                if (rankedLastSeasonResults.Any(r => rankedLastSeasonResults.Any(r2 => r2.Team != r.Team && r2.Wins == r.Wins && r2.PointsFor == r.PointsFor)))
                {
                    List<SeasonResult> tiedResults = rankedLastSeasonResults.Where(r => rankedLastSeasonResults.Any(r2 => r2.Team != r.Team && r2.Wins == r.Wins && r2.PointsFor == r.PointsFor)).ToList();

                    List<SeasonResult> headToHead = new List<SeasonResult>();
                    foreach(var result in tiedResults)
                    {
                        foreach(var opposingTeam in tiedResults.Where(r => r.Team != result.Team).Select(r => r.Team))
                        {
                            headToHead.Add(new SeasonResult(result.Team, result.GetMatchesVs(opposingTeam)));
                        }
                    }

                    int placeIndex = tiedResults.Min(r => r.Placement);

                    foreach(var teamResult in headToHead)
                    {
                        tiedResults.First(r => r.Team == teamResult.Team).Placement = placeIndex;
                        placeIndex++;
                    }

                    rankedLastSeasonResults.OrderBy(r => r.Placement);
                }
            }

            Dictionary<Team, double> playoffOdds = new Dictionary<Team, double>();
            List<string> lines = new List<string>();
            foreach (var team in Schedule.Teams)
            {
                IEnumerable<SeasonResult> teamResults = SeasonResults.Where(r => r.Key == team).SelectMany(r => r.Value);
                double odds = (double)teamResults.Count(sr => sr.MadePlayoffs.Value) / (double)teamResults.Count();
                playoffOdds.Add(team, odds);

                StringBuilder sb = new StringBuilder($"{team}");

                for(int i = 0; i <= 13; i++)
                {
                    sb.Append("," + ((double)teamResults.Count(sr => sr.Wins == i) / (double)teamResults.Count()).ToString("P"));
                }
                sb.Append("," + playoffOdds.Last().Value.ToString("P"));
                lines.Add(sb.ToString());
            }
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);

            File.WriteAllLines(Path.Combine(Utilities.Files.AssemblyDirectory, @"..\Data\Output.csv"), lines.ToArray());


            Console.ReadKey();
        }

        public static Result GetMatchupResult(MatchupTeamInfo team1Showing, MatchupTeamInfo team2Showing)
        {
            return new Result(team1Showing.Team, team1Showing.GetScore(), team2Showing.Team, team2Showing.GetScore());
        }
        
    }
}
