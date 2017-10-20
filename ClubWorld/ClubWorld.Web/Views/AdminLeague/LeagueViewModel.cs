using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClubWorld.Views.AdminLeague
{
    public class LeagueViewModel
    {
        public string LeagueId { get; set; }
        public IEnumerable<SelectListItem> LeagueList { get; set; }
    }
}