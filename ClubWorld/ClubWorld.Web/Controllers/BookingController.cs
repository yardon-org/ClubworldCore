using ClubWorld.Models.Booking;
using ClubWorld.Models.Booking.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClubWorld.Controllers
{
    public class BookingController : Controller
    {
        // GET: Booking
        public ActionResult Index()
        {
            return View(BookingUtilities.PrepareModel(new DateTime(2013, 10, 01)));
        }

        [HttpPost]
        public JsonResult AjaxShowBookingForm(string RequestedDate)
        {
            ShowDayViewModel sdv = BookingUtilities.PrepareModel(DateTime.Parse(RequestedDate));

            return Json(sdv);
        }
        public ActionResult GetBookingDetails(string DateRequested)
        {
            return PartialView("_RinkSheetPartial", BookingUtilities.PrepareModel(DateTime.Parse(DateRequested)));
        }

        public ActionResult RinkBooking(JSONSession Bookings)
        {
            BookingUtilities.BookSession(Bookings);
            JsonResult j = new JsonResult();
            j.Data = "Success";
            return j;
        }
    }
}