using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClubWorld.Models.League
{
    public class LeagueTableViewModel
    {
        public string TeamName { get; set; }
        public int Played { get; set; }
        public int GamesWon { get; set; }
        public int GamesDrawn { get; set; }
        public int GamesLost { get; set; }
        public int ShotsFor { get; set; }
        public int ShotsAgainst { get; set; }
        public int ShotDifference { get; set; }
        public float Points { get; set; }

    }
}