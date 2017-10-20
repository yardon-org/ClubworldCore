using ClubWorld.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClubWorld.Controllers
{
    public class LeagueAdminController : Controller
    {
        // GET: LeagueAdmin
        public ActionResult League()
        {
            //using (var db = new ClubWorldDbContext())
            //{
            //    return View(db);

            //}

            //ClubWorldDbContext db = new ClubWorldDbContext();
            
            return View();
        }

        [HttpPost]
        public ActionResult AddNew(string Description, int? PtsPerRink, int PtsPerWin, int RinksReqd)
        {
            //ClubWorldDbContext db = new ClubWorldDbContext();

            //var leagueEntry = new League_List { Description = Description, RinkPoints = PtsPerRink, WinPoints = PtsPerWin, TotalRinksRequired = RinksReqd};
            //db.League_List.Add(leagueEntry);
            //db.SaveChanges();

            return RedirectToAction("League");

        }

        public ActionResult LeagueAdmin(int LeagueID)
        {
            return View();
        }
    }
}