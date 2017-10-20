using System;
using System.Collections.Generic;

namespace ClubWorld.DataAccess.ClubWorldDB
{
    public partial class AuditBookingDiary
    {
        public int AuditId { get; set; }
        public int DiaryId { get; set; }
        public DateTime BookedDate { get; set; }
        public int? Type { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }
        public int? Status { get; set; }
        public int? PostponedRef { get; set; }
        public int? UserRef { get; set; }
    }
}
