using FantasyFootball.Data;
using FantasyFootball.Data.Yahoo;
using Meta.Numerics.Statistics.Distributions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace FantasyFootball
{

    public enum Outcome { None, Win, Loss, Tie }

    class Program
    {
        const int SIMULATIONS = 10000;

        //static IFantasyDataProvider provider = new CsvDataProvider();
        static IFantasyDataProvider provider = new YahooDataProvider();
        static Schedule Schedule;
        static double ActualScores_StandardDeviation;

        static void Main(string[] args)
        {
            provider.GetTeams();

            Schedule = provider.GetSchedule();

            // Load result data structure
            Dictionary<Team, List<SeasonResult>> SeasonResults = new Dictionary<Team, List<SeasonResult>>();
            foreach (var team in Schedule.Teams)
            {
                SeasonResults.Add(team, new List<SeasonResult>());
            }

            IEnumerable<double> allScores = Schedule.Weeks.SelectMany(w => w.Matchups).Select(m => m.Team1ScoreInformation).Where(i => i.ActualScore.HasValue).Select(i => i.ActualScore.Value).Concat(Schedule.Weeks.SelectMany(w => w.Matchups).Select(m => m.Team2ScoreInformation).Where(i => i.ActualScore.HasValue).Select(i => i.ActualScore.Value));
            ActualScores_StandardDeviation = MathJ.StandardDeviation(allScores);

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            List<string> allResults = new List<string>();

            StringBuilder header = new StringBuilder(",");
            for (int i = 1; i <= Schedule.Teams.Count; i++)
            {
                header.Append($"{i},");
            }
            allResults.Add(header.ToString());

            // Simulate seasons
            for (int i = 0; i < SIMULATIONS; i++)
            {
                if((i + 1) % 1000 == 0)
                {
                    Console.WriteLine($"Simulating season {i + 1}...");
                }

                StringBuilder resultsStringBuilder = new StringBuilder($"{i + 1},");
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
                    foreach (var result in tiedResults)
                    {
                        foreach (var opposingTeam in tiedResults.Where(r => r.Team != result.Team).Select(r => r.Team))
                        {
                            headToHead.Add(new SeasonResult(result.Team, result.GetMatchesVs(opposingTeam)));
                        }
                    }

                    int placeIndex = tiedResults.Min(r => r.Placement);

                    foreach (var teamResult in headToHead)
                    {
                        tiedResults.First(r => r.Team == teamResult.Team).Placement = placeIndex;
                        placeIndex++;
                    }

                    rankedLastSeasonResults.OrderBy(r => r.Placement);
                }

                foreach (var result in rankedLastSeasonResults)
                {
                    resultsStringBuilder.Append($"{result.Team} - {result.RecordString} - {result.PointsFor},");
                }
                allResults.Add(resultsStringBuilder.ToString());
            }

            Console.WriteLine($"Simulations complete. Generating output csv...");

            Dictionary<Team, double> playoffOdds = new Dictionary<Team, double>();
            List<string> summary = new List<string>();

            header = new StringBuilder(",");
            for (int i = 0; i <= 13; i++)
            {
                header.Append($"({i}-{13 - i}-0),");
            }
            summary.Add(header.ToString());

            foreach (var team in Schedule.Teams)
            {
                IEnumerable<SeasonResult> teamResults = SeasonResults.Where(r => r.Key == team).SelectMany(r => r.Value);
                double odds = (double)teamResults.Count(sr => sr.MadePlayoffs.Value) / (double)teamResults.Count();
                playoffOdds.Add(team, odds);

                StringBuilder sb = new StringBuilder($"{team}");

                for (int i = 0; i <= 13; i++)
                {
                    sb.Append("," + ((double)teamResults.Count(sr => sr.Wins == i) / (double)teamResults.Count()).ToString("P"));
                }
                sb.Append("," + playoffOdds.Last().Value.ToString("P"));
                summary.Add(sb.ToString());
            }

            File.WriteAllLines(Path.Combine(Files.ProjectDirectory, @"Data\Summary.csv"), summary.ToArray());
            File.WriteAllLines(Path.Combine(Files.ProjectDirectory, @"Data\Results.csv"), allResults.ToArray());

            stopwatch.Stop();
            Console.WriteLine($"Completed in {stopwatch.Elapsed}");
        }

        public static Result GetMatchupResult(MatchupTeamInfo team1Showing, MatchupTeamInfo team2Showing)
        {

            return new Result(team1Showing.Team, team1Showing.GetScore(ActualScores_StandardDeviation), team2Showing.Team, team2Showing.GetScore(ActualScores_StandardDeviation));
        }

    }
}
