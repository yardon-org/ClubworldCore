using ClubWorld.Models.League;
using ClubWorld.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClubWorld.Models.League.Results
{
    public class AddResultViewModel
    {
        public Fixture Details { get; set; }
        public List<Player> HomePlayers { get; set; }
        public List<Player> AwayPlayers { get; set; }
        public List<LeagueFixtureType> FixtureTypeList { get; set; }
    }
}
