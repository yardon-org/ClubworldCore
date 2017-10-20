using System;
using System.Collections.Generic;

namespace ClubWorld.DataAccess.ClubWorldDB
{
    public partial class LeagueFixtureType
    {
        public int FixtureTypeId { get; set; }
        public string Name { get; set; }
        public int PlayersPerRink { get; set; }
        public int RinksRequired { get; set; }
        public int PointsPerGame { get; set; }
        public int? PointsPerRink { get; set; }
    }
}
