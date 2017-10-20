using ClubWorld.Models.League;
using ClubWorld.Models.League.Results;
using ClubWorld.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClubWorld.Controllers
{
    public class LeagueController : Controller
    {
        // GET: League
        public ActionResult Index()
        {
            return View(Utilities.AllLeagues());
        }
        public ActionResult Table(int LeagueId)
        {
            return PartialView("Partial_LeagueTable", Utilities.GetLeagueTable(LeagueId));
        }

#region "Results"
        public ActionResult Result(string LeagueId)
        {
            return PartialView("Partial_FixtureList", Utilities.FixturesForLeague(Int32.Parse(LeagueId)));
        }
        public ActionResult Fixtures(string LeagueId)
        {
            return PartialView("Partial_FixtureList", Utilities.FixturesForLeague(Int32.Parse(LeagueId)));
        }
        public ActionResult AddResult(Fixture FixtureObj)
        {
 
            return PartialView("Partial_AddResult", Utilities.AddResult(FixtureObj));
        }
        public ActionResult InsertResult(List<ResultRecord> res)
        {
            Utilities.InsertResultToDb(res);
            JsonResult j = new JsonResult();
            j.Data = "Success";
            return j;
        }
#endregion
        public ActionResult FixtureList(int LeagueId)
        {
            return View();
        }
    }
}