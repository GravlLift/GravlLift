using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyFootball.Data
{
    public class CsvDataProvider : IFantasyDataProvider
    {
        public List<FantasyFootball.Team> Teams;

        Schedule IFantasyDataProvider.GetSchedule()
        {
            List<Data.Team> teams = Data.CsvObjectLoader.LoadObjects<Data.Team>(@"Data\Local\Team.csv");
            Teams = teams.Select(t => new FantasyFootball.Team(t.Name)).ToList();

            List<Data.Matchup> matchups = Data.CsvObjectLoader.LoadObjects<Data.Matchup>(@"Data\Local\Matchup.csv");
            List<Data.ScoreInformation> scoreInfo = Data.CsvObjectLoader.LoadObjects<Data.ScoreInformation>(@"Data\Local\ScoreInformation.csv");

            Schedule schedule = new Schedule
            {
                Teams = Teams
            };
            foreach (var match in matchups)
            {
                Data.Team dataTeam1 = teams.First(t => t.Id == match.Team1Id);
                Data.ScoreInformation dataScoreInfo1 = scoreInfo.First(i => i.TeamId == dataTeam1.Id && i.MatchupId == match.Id);
                Data.Team dataTeam2 = teams.First(t => t.Id == match.Team2Id);
                Data.ScoreInformation dataScoreInfo2 = scoreInfo.First(i => i.TeamId == dataTeam2.Id && i.MatchupId == match.Id);

                FantasyFootball.Team team1 = schedule.Teams.First(team => team.Name == dataTeam1.Name);
                MatchupTeamInfo team1Info = new MatchupTeamInfo(team1, dataScoreInfo1.ActualScore, dataScoreInfo1.ProjectedScore);
                FantasyFootball.Team team2 = schedule.Teams.First(team => team.Name == dataTeam2.Name);
                MatchupTeamInfo team2Info = new MatchupTeamInfo(team2, dataScoreInfo2.ActualScore, dataScoreInfo2.ProjectedScore);

                FantasyFootball.Matchup matchup = new FantasyFootball.Matchup(team1Info, team2Info);

                Week thisWeek = schedule.Weeks.FirstOrDefault(w => w.WeekNumber == match.WeekNum);

                if (thisWeek == null)
                {
                    schedule.Weeks.Add(new Week
                    {
                        WeekNumber = match.WeekNum,
                        Matchups = new List<FantasyFootball.Matchup> { matchup }
                    });
                }
                else
                {
                    thisWeek.Matchups.Add(matchup);
                }
            }
    return schedule;
        }

        List<FantasyFootball.Team> IFantasyDataProvider.GetTeams()
        {
            if (Teams == null)
            {
                
            }
            return Teams;
        }
    }
}
