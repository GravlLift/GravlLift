using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyFootball.Data
{
    interface IFantasyDataProvider
    {
        List<FantasyFootball.Team> GetTeams();
        FantasyFootball.Schedule GetSchedule();
    }
}
