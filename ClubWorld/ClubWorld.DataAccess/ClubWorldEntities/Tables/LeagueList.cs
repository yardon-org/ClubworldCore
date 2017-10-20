using System;
using System.Collections.Generic;

namespace ClubWorld.DataAccess.ClubWorldDB
{
    public partial class LeagueList
    {
        public LeagueList()
        {
            LeagueTeams = new HashSet<LeagueTeams>();
        }

        public int LeagueId { get; set; }
        public string Description { get; set; }
        public int? FixtureTypeRef { get; set; }
        public int? DisplayColour { get; set; }

        public ICollection<LeagueTeams> LeagueTeams { get; set; }
    }
}
