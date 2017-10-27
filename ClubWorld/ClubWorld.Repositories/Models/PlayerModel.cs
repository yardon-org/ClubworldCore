using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClubWorld.Repositories.Models
{
    public class PlayerModel
    {
        public int Id { get; set; }
        public int RegistrationId { get; set; }
        public string Name { get; set; }
    }
}