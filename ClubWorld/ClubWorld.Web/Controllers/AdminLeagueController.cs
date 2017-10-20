using ClubWorld.Models.DataAccess;
using ClubWorld.Models.Fixtures;
using ClubWorld.Models.League;
using ClubWorld.Models.ExtensionMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClubWorld.Models;

namespace ClubWorld.Controllers
{
    public class AdminLeagueController : Controller
    {
        public ActionResult Player()
        {
            return View();
        }

        public ActionResult League()
        {
            LeagueListViewModel lvm = new LeagueListViewModel();
            lvm.ClubWorldLeagues = _Repository.GetBowlsLeagues();
       
            return View(lvm);
        }
        public ActionResult Edit(int Id)
        {
            Teams league = new Teams(Id);
            LeagueEditViewModel obj = new LeagueEditViewModel();
            obj.Teams = league.CurrentLeague;
            obj.LeagueName = league.LeagueName;
            obj.LeagueId = Id;
            obj.Sessions = _Repository.Sessions();
            return View(obj);
        }

        [HttpPost]
        public ActionResult Edit(List<string> session, int LeagueId, List<string>  DaysSelected, DateTime StartDate, int Repeats)
        {
            Teams league = new Teams(LeagueId);
            FixtureUtilities fu = new FixtureUtilities();

            Fixtures fix = fu.Process(league, StartDate, session, DaysSelected, false, Repeats);


            FixtureViewModel fvm = fu.FixtureList(fix);
            return View("Fixtures",fvm);
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

         // GET: AdminLeague/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdminLeague/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
