using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubWorld.Repositories.Models
{
    public class LeagueFixtureModel
    {
        public int FixturteTypeId { get; set; }
        public string Description { get; set; }
        public int RinksRequired { get; set; }
    }
}
