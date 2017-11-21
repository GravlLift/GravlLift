using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FantasyFootball
{
    public class Team
    {
        public String Name { get; set; }
        
        public Team(string name)
        {
            Name = name;
        }

        public override bool Equals(object obj)
        {
            Team otherTeam = obj as Team;

            return Name == otherTeam?.Name;
        }

        public static bool operator ==(Team a, Team b)
        {
            return a.Equals(b);
        }
        public static bool operator !=(Team a, Team b)
        {
            return !a.Equals(b);
        }

        public override int GetHashCode()
        {
            return 539060726 + EqualityComparer<string>.Default.GetHashCode(Name);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
