using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClubWorld.Models.League
{
    public class Player
    {
        public int Id { get; set; }
        public int RegistrationId { get; set; }
        public string Name { get; set; }
    }
}