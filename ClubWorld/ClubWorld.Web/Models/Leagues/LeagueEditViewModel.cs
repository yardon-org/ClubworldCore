using ClubWorld.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClubWorld.Models.League
{
    public class LeagueEditViewModel
    {
        public List<Team>  Teams { get; set; }
        public string LeagueName { get; set; }
        public int LeagueId { get; set; }
        public List<AvailableSession> Sessions { get; set; }

    }
}