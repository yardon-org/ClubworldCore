using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClubWorld.Models.LeagueResults;

namespace ClubWorld.Controllers
{
    public class LeagueResultsController : Controller
    {
        // GET: LeagueResults
        public ActionResult Index()
        {
            return View(ResultsUtilities.AllLeagues());
        }
         public ActionResult Fixtures(string LeagueId)
        {
            return PartialView("FixturePartial", ResultsUtilities.FixturesForLeague(Int32.Parse(LeagueId)));
        }
        public ActionResult AddResult(Fixture FixtureObj)
        {
            //JsonResult j =new JsonResult();
            //j.Data = PartialView("AddResultPartial", ResultsUtilities.AddResult(FixtureObj));
            //return j;

            return PartialView("AddResultPartial", ResultsUtilities.AddResult(FixtureObj));
        }
        public ActionResult InsertResult(List<ResultRecord> res)
        {
            ResultsUtilities.InsertResultToDb(res);
            JsonResult j = new JsonResult();
            j.Data = "Success";
            return j;
        }
    }
}