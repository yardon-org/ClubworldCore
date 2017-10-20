using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClubWorld.Models
{
    public class LeagueUtilities
    {
        //public List<ClubLeague> Populate(ClubWorldDbContext db)
        //{
        //    var query =
        //        from l in db.League_List
        //        select l.LeagueId = LEAGUEid,
        //}
    }
    public class ClubLeague
    {
        public int LeagueID { get; set; }
        public string LeagueName { get; set; }
        public int PointsPerRink { get; set; }
        public int PointsPerWin { get; set; }
        public int RinksRequiredPerGame { get; set; }
    }

    public class CurrentLeague
    {
        public List<ClubLeague> AllLeagues { get; set; }
    }
}