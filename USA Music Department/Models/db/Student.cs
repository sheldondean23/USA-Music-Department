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
    
    public partial class Student
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Student()
        {
            this.StudentContacts = new HashSet<StudentContact>();
            this.InterestAreatoStudents = new HashSet<InterestAreatoStudent>();
        }
    
        public int StudentID { get; set; }
        public string StudentFirstName { get; set; }
        public string StudentLastName { get; set; }
        public string StudentAddress { get; set; }
        public string StudentCity { get; set; }
        public string StudentState { get; set; }
        public string StudentZipCode { get; set; }
        public string StudentPhone { get; set; }
        public string PerformanceMedium { get; set; }
        public string GraduationYear { get; set; }
        public string EmailAddress { get; set; }
        public System.DateTime ApplicationDate { get; set; }
        public string ApplicationDateSubString { get { return ApplicationDate.ToString().Substring(0, 8); } }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudentContact> StudentContacts { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InterestAreatoStudent> InterestAreatoStudents { get; set; }
    }
}
