using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClubWorld.Models.League
{
    public class LeagueFixtureType
    {
        public int FixturteTypeId { get; set; }
        public string Description { get; set; }
        public int RinksRequired { get; set; }
    }
}