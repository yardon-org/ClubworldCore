using ClubWorld.Models.League;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClubWorld.Models.Shared
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Player> TeamMembers { get; set; }   
    }
}