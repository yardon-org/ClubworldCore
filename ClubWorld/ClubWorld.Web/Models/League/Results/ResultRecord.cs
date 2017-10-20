using ClubWorld.Models.League;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClubWorld.Models.League.Results
{
    public class ResultRecord
    {
        public int FixtureRef { get; set; }
        public int FixtureType { get; set; }
        public int HomeShots { get; set; }
        public int AwayShots { get; set; }
        public List<Player> HomeRink { get; set; }
        public List<Player> AwayRink { get; set; }
    }
}
