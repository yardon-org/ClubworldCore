using ClubWorld.Database.EntityModel;
using ClubWorld.Models.League;
using ClubWorld.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubWorld.Repository.Services
{
    public class Fixtures
    {
        ClubWorldDbContext db = new ClubWorldDbContext();
        public IEnumerable<LeagueDetails> GetBowlsLeagues()
        {
            Repository<League_List> repo = new Repository<League_List>(db);
            return (from lg in repo.GetAll()
                      select new LeagueDetails
                      {
                          Id = lg.LeagueId,
                          Name = lg.Description
                      }).ToList();
        }
        public IEnumerable<Team> GetTeamsInLeague(int LeagueID)
        {
            Repository<League_Teams> repo = new Repository<League_Teams>(db);
            return (from Team in repo.GetAll()
                    where Team.LeagueRef == LeagueID
                    select new Team
                    {
                        Name = Team.TeamName,
                        Id = Team.TeamId
                    }).ToList();
        }
        public string GetLeagueName(int Id)
        {
            Repository<League_List> repo = new Repository<League_List>(db);
            return
                 (from lg in repo.GetAll()
                  where lg.LeagueId == Id
                  select lg.Description).Single();
        }
        public int GetFixtureType(string identifier)
        {
            Repository<Booking_Type> repo = new Repository<Booking_Type>(db);
            return
                (from type in db.Booking_Type
                 where type.TypeEnum == identifier
                 select type.TypeId).Single();
        }
        public int? GetRinksPerGame(int LeagueId)
        {
            
            Repository<VW_League_Details>  repo = new Repository<VW_League_Details>(db);
            return
                (from lg in repo.GetAll()
                 where lg.LeagueId == LeagueId
                 select lg.RinksPerFixtue).Single();

        }
        public List<AvailableSession> Sessions()
        {
            Repository<Booking_AvailableSessions> repo = new Repository<Booking_AvailableSessions>(db);
            return
                (from session in repo.GetAll()
                 select new AvailableSession
                 {
                     StartingAt = session.StartTime,
                     EndingAfter = session.EndTime,
                     Id = session.SessionId
                 }).ToList();
        }
        public int MaxSessions()
        {
            Repository<Booking_AvailableSessions> repo = new Repository<Booking_AvailableSessions>(db);
            return repo.Top(m => m.SessionId);
        }

    }
    //class Fixtures : Repository<League_List>
    //{
    //    public Fixtures(ClubWorldDbContext context)
    //        : base(context)
    //    {
    //    }
    //}
}
