using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClubWorld.Repositories.Models
{
    public class ResultModel
    {
        public int FixtureRef { get; set; }
        public int FixtureType { get; set; }
        public int HomeShots { get; set; }
        public int AwayShots { get; set; }
        public List<PlayerModel> HomeRink { get; set; }
        public List<PlayerModel> AwayRink { get; set; }
    }
}
