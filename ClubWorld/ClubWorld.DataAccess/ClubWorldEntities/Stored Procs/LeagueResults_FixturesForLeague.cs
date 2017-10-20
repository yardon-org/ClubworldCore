using System;
using System.Collections.Generic;
using System.Text;

namespace ClubWorld.DataAccess.ClubWorldDB.Stored_Procs
{
    public partial class LeagueResults_FixturesForLeague
    {
        public int FixtureId { get; set; }
        public int DiaryId { get; set; }
        public string Description { get; set; }
        public DateTime BookedDate { get; set; }
        public int HomeTeamRef { get; set; }
        public string HomeName { get; set; }
        public int AwayTeamRef { get; set; }
        public string AwayName { get; set; }
        public int Status { get; set; }
        public Boolean Completed { get; set; }
    }
}
