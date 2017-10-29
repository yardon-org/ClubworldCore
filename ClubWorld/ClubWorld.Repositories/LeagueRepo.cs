using ClubWorld.Data.SQL.Entities;
using ClubWorld.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubWorld.Repositories
{
    public class LeagueRepo
    {
        ClubWorldContext _db = new ClubWorldContext();
        public List<LeagueDetailsModel> GetAllLeagues()
        {
            return (
                    from league in _db.League_List
                    select new LeagueDetailsModel
                    {
                        Id = league.LeagueId,
                        Name = league.Description
                    }).ToList();
        }
        public IEnumerable<LeagueTableModel> GetLeagueTable(int LeagueId)
        {
            return
                (from l in _db.League_ShowLeagueTable(LeagueId)
                 select new LeagueTableModel
                 {
                     Difference = l.Diff ?? 0,
                     Drawn = l.Drawn ?? 0,
                     Lost = l.Lost ?? 0,
                     Played = l.Played ?? 0,
                     Points = l.Points,
                     ShotsAgainst = l.ShotsAgainst ?? 0,
                     ShotsFor = l.ShotsFor ?? 0,
                     TeamName = l.TeamName
                 });
        }
    }
}
