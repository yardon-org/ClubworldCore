using ClubWorld.Models.League;
using ClubWorld.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClubWorld.Models
{
    public class AddResultViewModel
    {
        public FixtureModel Details { get; set; }
        public List<PlayerModel> HomePlayers { get; set; }
        public List<PlayerModel> AwayPlayers { get; set; }
        public List<LeagueFixtureModel> FixtureTypeList { get; set; }
    }
}
