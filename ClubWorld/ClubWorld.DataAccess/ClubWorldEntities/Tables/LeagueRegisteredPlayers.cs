using System;
using System.Collections.Generic;

namespace ClubWorld.DataAccess.ClubWorldDB
{
    public partial class LeagueRegisteredPlayers
    {
        public int RegistrationId { get; set; }
        public int TeamRef { get; set; }
        public int PlayerRef { get; set; }

        public LeagueTeams TeamRefNavigation { get; set; }
    }
}
