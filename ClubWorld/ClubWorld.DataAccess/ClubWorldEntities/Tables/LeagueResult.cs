using System;
using System.Collections.Generic;

namespace ClubWorld.DataAccess.ClubWorldDB
{
    public partial class LeagueResult
    {
        public int ResultId { get; set; }
        public int FixtureRef { get; set; }
        public int ResultType { get; set; }
        public int HomeShots { get; set; }
        public int AwayShots { get; set; }

        public LeagueFixtures FixtureRefNavigation { get; set; }
    }
}
