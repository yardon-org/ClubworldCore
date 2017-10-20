using ClubWorld.Models.Booking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClubWorld.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //BookingUtilities bu = new BookingUtilities();

            return View(BookingUtilities.PrepareModel(new DateTime(2013, 10, 01)));
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}