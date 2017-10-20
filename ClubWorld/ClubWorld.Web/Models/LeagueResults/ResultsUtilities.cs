using ClubWorld.Models.DataAccess;
using ClubWorld.Models.League;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClubWorld.Models.LeagueResults
{
    public static class ResultsUtilities
    {
        public static ResultViewModel AllLeagues()
        {
            ResultViewModel rvm = new ResultViewModel();
            rvm.LeagueList = _Repository.LeagueResults_GetLeagueList();
            return rvm;
        }

        public static ResultViewModel FixturesForLeague(int LeagueId)
        {
            ResultViewModel rvm = new ResultViewModel();
            rvm.LeagueId = LeagueId;
            rvm.Fixtures = _Repository.LeagueResults_FixturesForLeague(LeagueId);

            //foreach (LeagueResults_FixturesForLeague_Result r in _Repository.LeagueResults_FixturesForLeague(LeagueId))
            //{
            //    Fixture f = new Fixture();

            //    f.FixtureRef = r.FixtureId;
            //    //f.DiaryRef = r.DiaryId;
            //    f.BookedDate = r.BookedDate.ToString(@"ddd dd MMM yyyy");
            //    f.LeagueName = r.Description;
            //    f.HomeTeamRef = r.HomeTeamRef;
            //    f.HomeTeamName = r.HomeName;
            //    f.AwayTeamRef = r.AwayTeamRef;
            //    f.AwayTeamName = r.AwayName;
            //    //f.FixtureType = r.FixtureTypeId;
                
            //    rvm.Fixtures.Add(f);

            //    //var json = new JavaScriptSerializer();
            //    //f.JsonData = JsonConvert.SerializeObject(f);
            //}

            return rvm;
        }
        public static AddResultViewModel AddResult(Fixture fixture)
        {
            AddResultViewModel rvm = new AddResultViewModel();

            rvm.Details = fixture;
            if(fixture.FixtureType == 0)
            {
                rvm.FixtureTypeList = _Repository.LeagueResult_GetFixtureTypes();
            }

            List<LeagueResult_TeamsForFixture_Result> players = _Repository.LeagueResult_GetTeamsForFixture(fixture.FixtureRef);
            rvm.HomePlayers = new List<Player>();
            rvm.AwayPlayers = new List<Player>();

            foreach(LeagueResult_TeamsForFixture_Result p in players)
            {
                Player play = new Player();
                play.Id = p.PlayerRef;
                play.RegistrationId = p.RegistrationId;
                play.Name = p.Forename.Substring(0,1) + " " + p.Surname;

                if(p.TeamRef==fixture.HomeTeamRef)
                {
                    rvm.HomePlayers.Add(play);
                }
                else
                {
                    rvm.AwayPlayers.Add(play);
                }
            }
            return rvm;
        }
        public static void InsertResultToDb(List<ResultRecord> res)
        {
            _Repository.LeagueResult_InsertResultRecords(res);
        }
    }
}