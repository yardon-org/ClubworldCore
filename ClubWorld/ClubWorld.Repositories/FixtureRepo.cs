using ClubWorld.Data.SQL.Entities;
using ClubWorld.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubWorld.Repositories
{
    public class FixtureRepo
    {
        ClubWorldContext _db = new ClubWorldContext();
        public IEnumerable<LeagueDetailsModel> GetBowlsLeagues()
        {
            return (from lg in _db.League_List
                    select new LeagueDetailsModel
                    {
                        Id = lg.LeagueId,
                        Name = lg.Description
                    }
                    ).ToList();
        }
        public IEnumerable<TeamModel> GetTeamsInLeague(int LeagueID)
        {
            return (from Team in _db.League_Teams
                    where Team.LeagueRef == LeagueID
                    select new TeamModel
                    {
                        Name = Team.TeamName,
                        Id = Team.TeamId
                    }).ToList();
        }
        public string GetLeagueName(int Id)
        {
            return
                 (from lg in _db.League_List
                  where lg.LeagueId == Id
                  select lg.Description).Single();
        }
        public int GetFixtureType(string identifier)
        {
            return
                (from type in _db.Booking_Type
                 where type.TypeEnum == identifier
                 select type.TypeId).Single();
        }
        public int? GetRinksPerGame(int LeagueId)
        {
            return
                (from lg in _db.VW_League_Details
                 where lg.LeagueId == LeagueId
                 select lg.RinksPerFixtue).Single();

        }
        public List<AvailableSessionModel> Sessions()
        {
            return
                (from session in _db.Booking_AvailableSessions
                 select new AvailableSessionModel
                 {
                     StartingAt = session.StartTime,
                     EndingAfter = session.EndTime,
                     Id = session.SessionId
                 }).ToList();
        }
        public int MaxSessions()
        {
            return _db.Booking_AvailableSessions.Max(m => m.SessionId);
        }
    }
}
