//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace USA_Music_Department.Models.db
{
    using System;
    using System.Collections.Generic;
    
    public partial class StudentContact
    {
        public int StudentContactId { get; set; }
        public Nullable<int> StudentId { get; set; }
        public Nullable<int> ContactedBy { get; set; }
        public Nullable<System.DateTime> ContactedDate { get; set; }
        public string ContactedMedium { get; set; }
    
        public virtual Student Student { get; set; }
        public virtual User User { get; set; }
    }
}
