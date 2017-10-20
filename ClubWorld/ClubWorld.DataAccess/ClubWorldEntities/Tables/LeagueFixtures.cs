using System;
using System.Collections.Generic;

namespace ClubWorld.DataAccess.ClubWorldDB
{
    public partial class LeagueFixtures
    {
        public LeagueFixtures()
        {
            LeagueResult = new HashSet<LeagueResult>();
        }

        public int FixtureId { get; set; }
        public int DiaryRef { get; set; }
        public int LeagueRef { get; set; }
        public int HomeTeamRef { get; set; }
        public int AwayTeamRef { get; set; }
        public int? FixtureTypeRef { get; set; }

        public BookingDiary DiaryRefNavigation { get; set; }
        public ICollection<LeagueResult> LeagueResult { get; set; }
    }
}
