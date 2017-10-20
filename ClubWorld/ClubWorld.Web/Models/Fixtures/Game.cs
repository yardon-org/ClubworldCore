using ClubWorld.Models.League;
using ClubWorld.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClubWorld.Models.Fixtures
{
    public class Game
    {
        private Team _homeTeam;
        private Team _awayTeam;
        public Game(Team Home, Team Away)
        {
            _homeTeam = Home;
            _awayTeam = Away;
        }
        public DateTime AssignedDate { get; set; }
        public  Team HomeTeam { get { return _homeTeam; } }
        public  Team AwayTeam { get { return _awayTeam; } }
        public int RinksUsedFlag { get; set; }
        public string Type { get; set; }
        public Game Reverse()
        {
            return new Game(this.AwayTeam, this.HomeTeam);
        }
    }
    
}
