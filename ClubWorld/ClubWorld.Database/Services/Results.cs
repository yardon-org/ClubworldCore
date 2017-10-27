using ClubWorld.Database.EntityModel;
using ClubWorld.Models.Shared;
using ClubWorld.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubWorld.Database.Services
{
    class Results
    {
        ClubWorldDbContext db = new ClubWorldDbContext();
        public List<Fixture> LeagueResults_FixturesForLeague(int LeagueId, int NoOfRecs = 10)
        {
            Repository<LeagueResults_FixturesForLeague_Result> repo = new Repository<LeagueResults_FixturesForLeague_Result>(db);
            using (ClubWorldDbContext db = new ClubWorldDbContext())
            {
                return
                     (from fix in repo.(LeagueId)
                      where fix.Completed == 0
                      select new Fixture
                      {
                          FixtureRef = fix.FixtureId,
                          DiaryRef = fix.DiaryId,
                          BookedDate = fix.BookedDate.ToString(@"ddd dd MMM yyyy"),
                          HomeTeamName = fix.HomeName,
                          HomeTeamRef = fix.HomeTeamRef,
                          AwayTeamName = fix.AwayName,
                          AwayTeamRef = fix.AwayTeamRef
                      }).Take(NoOfRecs).ToList();

                //return db.LeagueResults_FixturesForLeague(LeagueId).Take(NoOfRecs).ToList();
                return
                    (from fix in db.LeagueResults_FixturesForLeague(LeagueId)
                     where fix.Completed == 0
                     select new Fixture
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
        }
        public static List<LeagueResult_TeamsForFixture_Result> LeagueResult_GetTeamsForFixture(int FixtureId)
        {
            using (ClubWorldDbContext db = new ClubWorldDbContext())
            {
                return db.LeagueResult_TeamsForFixture(FixtureId).ToList();
            }
        }

        public static LeagueResults_GetFixture_Result LeagueResult_GetFixture(int FixtureId)
        {
            using (ClubWorldDbContext db = new ClubWorldDbContext())
            {
                return db.LeagueResults_GetFixture(FixtureId).SingleOrDefault();
            }
        }

        public static List<LeagueFixtureType> LeagueResult_GetFixtureTypes()
        {
            using (ClubWorldDbContext db = new ClubWorldDbContext())
            {
                return (
                    from ft in db.League_FixtureType
                    select new LeagueFixtureType
                    {
                        FixturteTypeId = ft.FixtureTypeId,
                        Description = ft.Name,
                        RinksRequired = ft.RinksRequired
                    }).ToList();
            }
        }
        public static int LeagueResult_AddResult(int FixtureRef, int HomeShots, int AwayShots)
        {
            ObjectParameter resultRef = new ObjectParameter("ResultId", typeof(Int32));
            using (ClubWorldDbContext db = new ClubWorldDbContext())
            {
                db.LeagueResults_AddResult(FixtureRef, HomeShots, AwayShots, resultRef);
                return (int)resultRef.Value;
            }
        }
        public static void LeagueResult_AddResultPlayers(int ResultRef, int RegistrationRef)
        {
            using (ClubWorldDbContext db = new ClubWorldDbContext())
            {
                db.LeagueResults_AddResultPlayers(ResultRef, RegistrationRef);
            }
        }

        public static void LeagueResult_InsertResultRecords(List<ResultRecord> resultList)
        {
            using (ClubWorldDbContext db = new ClubWorldDbContext())
            {
                DbContextTransaction tran = db.Database.BeginTransaction();

                foreach (ResultRecord res in resultList)
                {
                    League_Result resEntity = new League_Result
                    {
                        FixtureRef = res.FixtureRef,
                        ResultType = res.FixtureType,
                        HomeShots = res.HomeShots,
                        AwayShots = res.AwayShots
                    };
                    db.League_Result.Add(resEntity);

                    db.SaveChanges();

                    int resID = resEntity.ResultID;

                    League_Fixtures fixEntity = db.League_Fixtures.SingleOrDefault(lf => lf.FixtureId == res.FixtureRef);
                    fixEntity.FixtureTypeRef = res.FixtureType;

                    foreach (Player p in res.HomeRink)
                    {
                        League_ResultPlayers lrp = new League_ResultPlayers
                        {
                            ResultRef = resEntity.ResultID,
                            RegistrationRef = p.RegistrationId
                        };

                        db.League_ResultPlayers.Add(lrp);
                    }
                }
                db.SaveChanges();

                tran.Commit();
            }
        }
    }
}
