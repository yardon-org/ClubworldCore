using ClubWorld.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClubWorld.Models
{
    public class ResultViewModel
    {
        public List<LeagueDetailsModel> LeagueList { get; set; }
        public int LeagueId { get; set; }
        public string LeagueName { get { return Fixtures[0].LeagueName; } }
        public List<FixtureModel> Fixtures { get; set; }
    }
}