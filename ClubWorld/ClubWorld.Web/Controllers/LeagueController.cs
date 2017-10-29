using ClubWorld.Models;
using ClubWorld.Models.League;
using ClubWorld.Repositories;
using ClubWorld.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClubWorld.Controllers
{
    public class LeagueController : Controller
    {
        LeagueRepo leagueRepo = new LeagueRepo();
        // GET: League
        public ActionResult Index()
        {
            return View(leagueRepo.GetAllLeagues());
        }
        public ActionResult Table(int LeagueId)
        {
            return PartialView("Partial_LeagueTable", leagueRepo.GetLeagueTable(LeagueId));
        }

#region "Results"
#endregion
        public ActionResult FixtureList(int LeagueId)
        {
            return View();
        }
    }
}