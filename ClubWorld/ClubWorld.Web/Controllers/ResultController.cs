using ClubWorld.Models;
using ClubWorld.Repositories;
using ClubWorld.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClubWorld.Controllers
{
    public class ResultController : Controller
    {
        ResultRepo resRepo = new ResultRepo();
        // GET: Result
        public ActionResult Result(string LeagueId)
        {
            ResultViewModel rvm = new ResultViewModel();
            rvm.LeagueId = Int32.Parse(LeagueId);
            rvm.Fixtures = resRepo.LeagueResults_FixturesForLeague(rvm.LeagueId);

            return PartialView("Partial_FixtureList", rvm);
        }
        public ActionResult Fixtures(string LeagueId)
        {
            return PartialView("Partial_FixtureList",resRepo.LeagueResults_FixturesForLeague(Int32.Parse(LeagueId)));
        }
        public ActionResult AddResult(FixtureModel FixtureObj)
        {
            AddResultViewModel rvm = new AddResultViewModel();

            rvm.Details = FixtureObj;
            if (FixtureObj.FixtureType == 0)
            {
                rvm.FixtureTypeList = resRepo.LeagueResult_GetFixtureTypes();
            }

            var players = resRepo.LeagueResult_GetTeamsForFixture(FixtureObj.FixtureRef);
            rvm.HomePlayers = new List<PlayerModel>();
            rvm.AwayPlayers = new List<PlayerModel>();

            foreach (var p in players)
            {
                PlayerModel play = new PlayerModel();
                play.Id = p.PlayerRef;
                play.RegistrationId = p.RegistrationId;
                play.Name = p.Forename.Substring(0, 1) + " " + p.Surname;

                if (p.TeamRef == FixtureObj.HomeTeamRef)
                {
                    rvm.HomePlayers.Add(play);
                }
                else
                {
                    rvm.AwayPlayers.Add(play);
                }
            }

            return PartialView("Partial_AddResult", rvm);
        }
        public ActionResult InsertResult(List<ResultModel> res)
        {
            resRepo.InsertResultRecords(res);
            JsonResult j = new JsonResult();
            j.Data = "Success";
            return j;
        }
    }
}