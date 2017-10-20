using System;
using System.Collections.Generic;

namespace ClubWorld.DataAccess.ClubWorldDB
{
    public partial class CompetitionEntries
    {
        public int EntrantId { get; set; }
        public int CompetitionRef { get; set; }
        public int PlayerRef { get; set; }
    }
}
