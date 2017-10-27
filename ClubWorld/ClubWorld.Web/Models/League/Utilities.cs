using ClubWorld.Models.DataAccess;
using ClubWorld.Models.League.Results;
using ClubWorld.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClubWorld.Models.League
{
    public class Utilities
    {
        public static List<LeagueTableViewModel> GetLeagueTable(int LeagueId)
        {
            List<LeagueTableViewModel> LeagueTable = new List<LeagueTableViewModel>();

            foreach (var te in _Repository.GetLeagueTable(LeagueId))
            {
                LeagueTableViewModel tvm = new LeagueTableViewModel();

                tvm.GamesDrawn = te.Drawn ?? 0;
                tvm.GamesLost = te.Lost ?? 0;
                tvm.GamesWon = te.Won ?? 0;
                tvm.Played = te.Played ?? 0;
                tvm.Points = float.Parse(te.Points ?? "0");
                tvm.ShotDifference = te.Diff ?? 0;
                tvm.ShotsAgainst = te.ShotsAgainst ?? 0;
                tvm.ShotsFor = te.ShotsFor ?? 0;
                tvm.TeamName = te.TeamName;

                LeagueTable.Add(tvm);
            }

            return LeagueTable;
        }
        public static List<LeagueDetailsModel> AllLeagues()
        {
            return _Repository.LeagueResults_GetLeagueList();
        }

        public static ResultViewModel FixturesForLeague(int LeagueId)
        {
            ResultViewModel rvm = new ResultViewModel();
            rvm.LeagueId = LeagueId;
            rvm.Fixtures = _Repository.LeagueResults_FixturesForLeague(LeagueId);


            return rvm;
        }
        public static AddResultViewModel AddResult(Fixture fixture)
        {
            AddResultViewModel rvm = new AddResultViewModel();

            rvm.Details = fixture;
            if (fixture.FixtureType == 0)
            {
                rvm.FixtureTypeList = _Repository.LeagueResult_GetFixtureTypes();
            }

            List<LeagueResult_TeamsForFixture_Result> players = _Repository.LeagueResult_GetTeamsForFixture(fixture.FixtureRef);
            rvm.HomePlayers = new List<Player>();
            rvm.AwayPlayers = new List<Player>();

            foreach (LeagueResult_TeamsForFixture_Result p in players)
            {
                Player play = new Player();
                play.Id = p.PlayerRef;
                play.RegistrationId = p.RegistrationId;
                play.Name = p.Forename.Substring(0, 1) + " " + p.Surname;

                if (p.TeamRef == fixture.HomeTeamRef)
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