using ClubWorld.Database.EntityModel;
using ClubWorld.Repository;
using ClubWorld.Models.League;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubWorld.Database.Services
{
    class League
    {
        ClubWorldDbContext db = new ClubWorldDbContext();
        public List<LeagueDetails> LeagueResults_GetLeagueList()
        {
            Repository<League_List> repo = new Repository<League_List>(db);
            return (
                    from league in repo.GetAll()
                    select new LeagueDetails
                    {
                        Id = league.LeagueId,
                        Name = league.Description
                    }).ToList();
        }
        public List<League_ShowLeagueTable_Result> GetLeagueTable(int LeagueId)
        {
            Repository<League_ShowLeagueTable_Result> repo = new Repository<League_ShowLeagueTable_Result>(db);
            return repo.GetAll().ToList();
        }
    }
}
