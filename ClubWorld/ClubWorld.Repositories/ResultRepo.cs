using ClubWorld.Data.SQL.Entities;
using ClubWorld.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubWorld.Repositories
{
    public class ResultRepo
    {
        ClubWorldContext _db = new ClubWorldContext();
        public List<FixtureModel> LeagueResults_FixturesForLeague(int LeagueId, int NoOfRecs = 10)
        {
            return
                (from fix in _db.LeagueResults_FixturesForLeague(LeagueId)
                    where fix.Completed == 0
                    select new FixtureModel
                    {
                        FixtureRef = fix.FixtureId,
                        DiaryRef = fix.DiaryId,
                        BookedDate = fix.BookedDate.ToString(@"ddd dd MMM yyyy"),
                        HomeTeamName = fix.HomeName,
                        HomeTeamRef = fix.HomeTeamRef,
                        AwayTeamName = fix.AwayName,
                        AwayTeamRef = fix.AwayTeamRef
                    }).Take(NoOfRecs).ToList();
        }
        public List<TeamFixtureModel> LeagueResult_GetTeamsForFixture(int FixtureId)
        {
            return
                (from t in _db.LeagueResult_TeamsForFixture(FixtureId)
                 select new TeamFixtureModel
                 {
                     Forename = t.Forename,
                     PlayerRef = t.PlayerRef,
                     RegistrationId = t.RegistrationId,
                     Surname = t.Surname,
                     TeamRef = t.TeamRef
                 }
                 ).ToList();
        }

        public ResultFixture LeagueResult_GetFixture(int FixtureId)
        {
            return _db.LeagueResults_GetFixture(FixtureId).SingleOrDefault();
        }

        public List<LeagueFixtureModel> LeagueResult_GetFixtureTypes()
        {
            return (
                from ft in _db.League_FixtureType
                select new LeagueFixtureModel
                {
                    FixturteTypeId = ft.FixtureTypeId,
                    Description = ft.Name,
                    RinksRequired = ft.RinksRequired
                }).ToList();
        }
        public int AddResult(int FixtureRef, int HomeShots, int AwayShots)
        {
            ObjectParameter resultRef = new ObjectParameter("ResultId", typeof(Int32));
            _db.LeagueResults_AddResult(FixtureRef, HomeShots, AwayShots, resultRef);
            return (int)resultRef.Value;
        }
        public void AddResultPlayers(int ResultRef, int RegistrationRef)
        {
            _db.LeagueResults_AddResultPlayers(ResultRef, RegistrationRef);
        }

        public void InsertResultRecords(List<ResultModel> resultList)
        {
            DbContextTransaction tran = _db.Database.BeginTransaction();

            foreach (var res in resultList)
            {
                League_Result resEntity = new League_Result
                {
                    FixtureRef = res.FixtureRef,
                    ResultType = res.FixtureType,
                    HomeShots = res.HomeShots,
                    AwayShots = res.AwayShots
                };
                _db.League_Result.Add(resEntity);

                _db.SaveChanges();

                int resID = resEntity.ResultID;

                League_Fixtures fixEntity = _db.League_Fixtures.SingleOrDefault(lf => lf.FixtureId == res.FixtureRef);
                fixEntity.FixtureTypeRef = res.FixtureType;

                foreach (PlayerModel p in res.HomeRink)
                {
                    League_ResultPlayers lrp = new League_ResultPlayers
                    {
                        ResultRef = resEntity.ResultID,
                        RegistrationRef = p.RegistrationId
                    };

                    _db.League_ResultPlayers.Add(lrp);
                }
            }
            _db.SaveChanges();

            tran.Commit();
        }
    }
}
