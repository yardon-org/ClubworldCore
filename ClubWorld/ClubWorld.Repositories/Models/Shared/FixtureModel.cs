using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClubWorld.Repositories.Models
{
    public class FixtureModel
    {
        public int FixtureRef { get; set; }
        public int DiaryRef { get; set; }
        public string BookedDate { get; set; }
        public string LeagueName { get; set; }
        public int HomeTeamRef { get; set; }
        public string HomeTeamName { get; set; }
        public int AwayTeamRef { get; set; }
        public string AwayTeamName { get; set; }
        public int FixtureType { get; set; }
    }
}