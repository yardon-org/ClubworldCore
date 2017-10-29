using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubWorld.Repositories.Models
{
    public class LeagueTableModel
    {
        public string TeamName { get; set; }
        public int Played { get; set; }
        public int Won { get; set; }
        public int Drawn { get; set; }
        public int Lost { get; set; }
        public int ShotsFor { get; set; }
        public int ShotsAgainst { get; set; }
        public  int Difference { get; set; }
        public string Points { get; set; }
    }
}
