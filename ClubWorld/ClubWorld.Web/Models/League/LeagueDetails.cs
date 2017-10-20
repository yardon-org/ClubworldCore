using ClubWorld.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClubWorld.Models.League
{
    public class LeagueDetails
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public List<Team> Teams { get; set; }
    }
}