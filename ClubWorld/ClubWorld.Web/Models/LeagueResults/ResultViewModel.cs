using ClubWorld.Models.League;
using ClubWorld.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClubWorld.Models.LeagueResults
{
    public class ResultViewModel
    {
        public List<LeagueDetails> LeagueList { get; set;}
        public int LeagueId { get; set; }
        public string LeagueName { get  { return Fixtures[0].LeagueName; } }
        public List<Fixture> Fixtures { get; set; }
    }
}