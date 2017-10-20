using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClubWorld.Models.Fixtures
{
    public class Fixtures
    {
        private List<Games> _Series = new List<Games>();
        public List<Games> Series { get { return _Series; } }
        public int LeagueId { get; set; }
        public string LeagueName { get; set; }
        public int SessionFlag { get; set; }
        public int DayFlag { get; set; }
        public int TotalGames()
        {
            int totalGames = 0;
            foreach (Games g in _Series)
            {
                totalGames += g.Total();
            }
            return totalGames;
        }
        public void Reverse()
        {
            List<Games> reverse = new List<Games>();

            foreach (Games games in _Series)
            {
                reverse.Add(games.Reverse());
            }

            _Series.AddRange(reverse);
        }
    }
}