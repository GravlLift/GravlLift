using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FantasyFootball.Data.Yahoo
{
    class YahooDataProvider : IFantasyDataProvider
    {
        YahooApi yahooApi = new YahooApi();

        const string NFL_2017_ID = "371";
        const string LEAGUE_ID = "376646";

        string LeagueKey
        {
            get
            {
                return NFL_2017_ID + ".l." + LEAGUE_ID;
            }
        }

        List<FantasyFootball.Team> IFantasyDataProvider.GetTeams()
        {
            List<FantasyFootball.Team> teams = new List<FantasyFootball.Team>();
            League league = yahooApi.GetLeague(LeagueKey).FantasyResult.FirstOrDefault();
            for(int i = 1; i <= league.NumTeams; i++)
            {
                Team team = yahooApi.GetTeam(LeagueKey + "t" + i.ToString()).FantasyResult.FirstOrDefault();

                teams.Add(new FantasyFootball.Team(team.name));
            }

            return teams;
        }

        Schedule IFantasyDataProvider.GetSchedule()
        {
            throw new NotImplementedException();
        }
    }
}
