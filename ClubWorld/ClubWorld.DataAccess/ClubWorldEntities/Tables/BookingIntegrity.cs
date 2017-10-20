using System;
using System.Collections.Generic;

namespace ClubWorld.DataAccess.ClubWorldDB
{
    public partial class BookingIntegrity
    {
        public int IntegrityId { get; set; }
        public int BookingRef { get; set; }
        public DateTime BookedDate { get; set; }
        public int TeamRef { get; set; }
    }
}
