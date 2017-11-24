using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyFootball.Data.Yahoo
{
    class YahooDataProvider : IFantasyDataProvider
    {
        List<FantasyFootball.Team> IFantasyDataProvider.GetTeams()
        {
            throw new NotImplementedException();
        }

        Schedule IFantasyDataProvider.GetSchedule()
        {
            throw new NotImplementedException();
        }
    }
}
