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
    
    public partial class Booking_AvailableSessions
    {
        public int SessionId { get; set; }
        public System.TimeSpan StartTime { get; set; }
        public System.TimeSpan EndTime { get; set; }
        public string Name { get; set; }
    }
}
