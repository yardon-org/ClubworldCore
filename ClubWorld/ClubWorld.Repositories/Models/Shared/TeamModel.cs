using ClubWorld.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClubWorld.Repositories.Models
{
    public class TeamModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<PlayerModel> TeamMembers { get; set; }   
    }
}