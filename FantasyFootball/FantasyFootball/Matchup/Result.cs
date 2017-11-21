namespace FantasyFootball
{
    public class Result
    {
        public Team Team1;
        public double Team1Score;
        public Team Team2;
        public double Team2Score;

        public Result(Team team1, double team1Score, Team team2, double team2Score)
        {
            Team1 = team1;
            Team2 = team2;
            Team1Score = team1Score;
            Team2Score = team2Score;
        }

        public override string ToString()
        {
            return $"{Team1} {Team1Score} - {Team2Score} {Team2}";
        }
    }
}
