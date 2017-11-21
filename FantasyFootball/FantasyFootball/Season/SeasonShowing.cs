using System;
using System.Collections.Generic;

namespace FantasyFootball
{
    public class SeasonShowing
    {
        //public TeamSchedule Schedule;

        //public MatchupTeamInfo[] MatchupShowings;

        //public SeasonShowing(TeamSchedule schedule, params MatchupTeamInfo[] matchupShowings)
        //{
        //    if (schedule.Matchups.Count != matchupShowings.Length)
        //        throw new Exception($"Scheduled/Showings mismatch: {schedule.Matchups.Count}/{matchupShowings.Length}");

        //    MatchupShowings = matchupShowings;
        //}

        //public SeasonShowing(TeamSchedule schedule, params double?[] scores)
        //{
        //    if (schedule.Matchups.Count != scores.Length / 2)
        //        throw new Exception($"Scheduled/Scores(2x) mismatch: {schedule.Matchups.Count}/{scores.Length}");

        //    Schedule = schedule;
        //    List<MatchupTeamInfo> showings = new List<MatchupTeamInfo>();

        //    for (int i = 0; i < scores.Length - 1; i += 2)
        //    {
        //        showings.Add(new MatchupTeamInfo(scores[i], scores[i + 1]));
        //    }

        //    MatchupShowings = showings.ToArray();
        //}
    }
}
