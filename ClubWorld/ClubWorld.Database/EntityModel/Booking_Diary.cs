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
    
    public partial class Booking_Diary
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Booking_Diary()
        {
            this.League_Fixtures = new HashSet<League_Fixtures>();
        }
    
        public int DiaryId { get; set; }
        public string Description { get; set; }
        public System.DateTime BookedDate { get; set; }
        public System.DateTime DateAdded { get; set; }
        public Nullable<int> Status { get; set; }
        public Nullable<int> PostponedRef { get; set; }
        public Nullable<int> EntryType { get; set; }
        public Nullable<int> UserRef { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<League_Fixtures> League_Fixtures { get; set; }
    }
}