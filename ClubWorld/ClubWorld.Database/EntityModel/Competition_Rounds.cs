//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClubWorld.Database.EntityModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class Competition_Rounds
    {
        public int RoundId { get; set; }
        public int CompetitionRef { get; set; }
        public string RoundTitle { get; set; }
        public System.DateTime ClosingDate { get; set; }
    }
}
