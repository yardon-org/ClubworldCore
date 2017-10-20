using ClubWorld.Models.DataAccess;
using ClubWorld.Models.League;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClubWorld.Models.ExtensionMethods 
{
    public static class ClubWorld
    {
        //public static IEnumerable<SelectListItem> Leagues(ClubWorldDbContext db)
        public static IEnumerable<SelectListItem> ToSelectListLeague(this IEnumerable<LeagueDetails> Leagues,int SelectedId )
        {
            return
                Leagues.Select(lg => 
                    new SelectListItem
                    {
                        Selected = (lg.Id == SelectedId),
                        Text = lg.Name,
                        Value = lg.Id.ToString()
                    });
        }
    }
}