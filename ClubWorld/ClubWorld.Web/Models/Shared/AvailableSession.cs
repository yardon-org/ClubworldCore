using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClubWorld.Models.Shared
{
    public class AvailableSession
    {
        public TimeSpan StartingAt { get; set; }
        public TimeSpan EndingAfter { get; set; }
        public int Id { get; set; }
    }
}