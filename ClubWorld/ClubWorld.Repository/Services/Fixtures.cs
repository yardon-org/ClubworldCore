using ClubWorld.Database.EntityModel;
using ClubWorld.Models;
using ClubWorld.Models.ExtensionMethods;
using ClubWorld.Models.League;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubWorld.Repository.Services
{
    class Fixtures : Repository<LeagueDetails>
    {
        public Fixtures(ClubWorldDbContext context)
            : base(context)
        {

        }
    }
}
