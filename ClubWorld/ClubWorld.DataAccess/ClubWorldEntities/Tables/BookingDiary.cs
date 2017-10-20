using System;
using System.Collections.Generic;

namespace ClubWorld.DataAccess.ClubWorldDB
{
    public partial class BookingDiary
    {
        public BookingDiary()
        {
            LeagueFixtures = new HashSet<LeagueFixtures>();
        }

        public int DiaryId { get; set; }
        public string Description { get; set; }
        public DateTime BookedDate { get; set; }
        public DateTime DateAdded { get; set; }
        public int? Status { get; set; }
        public int? PostponedRef { get; set; }
        public int? EntryType { get; set; }
        public int? UserRef { get; set; }

        public ICollection<LeagueFixtures> LeagueFixtures { get; set; }
    }
}
