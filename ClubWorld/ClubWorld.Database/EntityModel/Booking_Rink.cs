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
    
    public partial class Booking_Rink
    {
        public int BookingId { get; set; }
        public int SessionRef { get; set; }
        public int Rink { get; set; }
        public int DiaryRef { get; set; }
    }
}