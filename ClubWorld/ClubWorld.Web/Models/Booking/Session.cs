using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClubWorld.Models.Booking
{
    public class Session
    {
        List<RinkUnit> _sessionList = new List<RinkUnit>();
        public Session(int Id)
        {
            SessionId = Id;
        }
        public List<RinkUnit> session { get { return _sessionList; } }
        public int SessionId { get; set; }
    }
}