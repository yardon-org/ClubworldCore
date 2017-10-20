using System;
using System.Collections.Generic;

namespace ClubWorld.DataAccess.ClubWorldDB
{
    public partial class BookingRink
    {
        public int BookingId { get; set; }
        public int SessionRef { get; set; }
        public int Rink { get; set; }
        public int DiaryRef { get; set; }
    }
}
