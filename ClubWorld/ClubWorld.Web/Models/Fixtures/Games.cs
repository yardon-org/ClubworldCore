using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClubWorld.Models.Fixtures;
namespace ClubWorld.Models.Fixtures
{
    public class Games
    {
        private List<Game> _Round = new List<Game>();
        public List<Game> Round 
        {
            get { return _Round; }
        }
        public int Total()
        {
            return _Round.Count(g => (g.AwayTeam.Id * g.HomeTeam.Id) > 0);
        }
        public Games Reverse()
        {
            Games reversed = new Games();

            foreach (Game game in _Round)
            {
                reversed.Round.Add(game.Reverse());
            }
            return reversed;
        }
    }
}