using ClubWorld.Repositories.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClubWorld.Repositories.Models
{
    public class LeagueDetailsModel
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public List<TeamModel> Teams { get; set; }
    }
}