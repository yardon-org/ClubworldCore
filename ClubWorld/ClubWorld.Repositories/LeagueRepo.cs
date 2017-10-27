using ClubWorld.Data.SQL.Entities;
using ClubWorld.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubWorld.Repositories
{
    class LeagueRepo
    {
        ClubWorldContext _db = new ClubWorldContext();
        public List<LeagueDetailsModel> LeagueResults_GetLeagueList()
        {
            return (
                    from league in _db.League_List
                    select new LeagueDetailsModel
                    {
                        Id = league.LeagueId,
                        Name = league.Description
                    }).ToList();
        }
        public List<League_ShowLeagueTable_Result> GetLeagueTable(int LeagueId)
        {
            return _db.League_ShowLeagueTable(LeagueId).ToList();
        }
    }
}
