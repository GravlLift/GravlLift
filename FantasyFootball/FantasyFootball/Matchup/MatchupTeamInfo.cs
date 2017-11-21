using Meta.Numerics.Statistics.Distributions;
using System;

namespace FantasyFootball
{
    public class MatchupTeamInfo
    {
        static Random rnd = new Random();
        static double STD_DEVIATION = 23.58967325;

        public Team Team;
        public double? ProjectedScore;
        public double? ActualScore;

        public MatchupTeamInfo(Team team, double? actualScore, double? projectedScore)
        {
            Team = team;
            ActualScore = actualScore;
            ProjectedScore = projectedScore;
        }

        public double GetScore()
        {
            if (ActualScore.HasValue)
                return ActualScore.Value;

            if (!ProjectedScore.HasValue)
                throw new Exception("No defined score data");

            NormalDistribution distribution = new NormalDistribution(ProjectedScore.Value, STD_DEVIATION);
            return Math.Round(distribution.GetRandomValue(rnd),2);
        }

    }
}
