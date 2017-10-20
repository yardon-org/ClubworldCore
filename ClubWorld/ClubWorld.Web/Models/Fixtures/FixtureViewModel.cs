using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClubWorld.Models.Fixtures
{
    public class FixtureViewModel
    {
        private List<Game> _fixtureList = new List<Game>();
        public List<Game> FixtureList { get { return _fixtureList; } }
    }
}