using Microsoft.EntityFrameworkCore;
using ClubWorld.DataAccess.ClubWorldDB.Stored_Procs;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClubWorld.DataAccess
{
    class Repository
    {
        public List<LeagueResults_FixturesForLeague> GetFixtures()
        {
            using (var context = new ClubWorldDB.ClubworldContext())
            {
                return context.LeagueResults_FixturesForLeague.FromSql("EXEC LeagueResults_FixturesForLeague").ToListAsync();
            }

    }
}
