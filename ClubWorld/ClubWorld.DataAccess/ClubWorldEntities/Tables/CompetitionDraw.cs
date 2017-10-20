using System;
using System.Collections.Generic;

namespace ClubWorld.DataAccess.ClubWorldDB
{
    public partial class CompetitionDraw
    {
        public int DrawId { get; set; }
        public int CompetitionRef { get; set; }
        public int? RoundRef { get; set; }
        public int? HomeRef { get; set; }
        public int? AwayRef { get; set; }
    }
}
