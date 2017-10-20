using System;
using System.Collections.Generic;

namespace ClubWorld.DataAccess.ClubWorldDB
{
    public partial class LeagueTeams
    {
        public LeagueTeams()
        {
            LeagueRegisteredPlayers = new HashSet<LeagueRegisteredPlayers>();
        }

        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public int LeagueRef { get; set; }

        public LeagueList LeagueRefNavigation { get; set; }
        public ICollection<LeagueRegisteredPlayers> LeagueRegisteredPlayers { get; set; }
    }
}
