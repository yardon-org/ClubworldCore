using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubWorld.Repositories.Models
{
    public class TeamFixtureModel
    {
        public int TeamRef { get; set; }
        public int RegistrationId { get; set; }
        public int PlayerRef { get; set; }
        public string Surname { get; set; }
        public string Forename { get; set; }
    }
}
