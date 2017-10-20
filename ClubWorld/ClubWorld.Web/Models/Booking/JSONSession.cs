using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClubWorld.Models.Booking
{
    public class JSONSession
    {
        public string BookingDate { get; set; }
        public string Description { get; set; }
        public List<JSONRinkUnit> RequestedSessions { get; set; }
    }
}