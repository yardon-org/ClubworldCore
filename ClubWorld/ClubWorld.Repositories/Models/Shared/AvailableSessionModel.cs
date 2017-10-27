using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClubWorld.Repositories.Models
{
    public class AvailableSessionModel
    {
        public TimeSpan StartingAt { get; set; }
        public TimeSpan EndingAfter { get; set; }
        public int Id { get; set; }
    }
}