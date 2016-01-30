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
    using System.ComponentModel.DataAnnotations;
    public partial class Student
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Student()
        {
            this.StudentContacts = new HashSet<StudentContact>();
            this.InterestAreatoStudents = new HashSet<InterestAreatoStudent>();
        }
    
        public int StudentID { get; set; }

        [Required()]
        [Display(Name = "Student First Name")]
        public string StudentFirstName { get; set; }

        [Required()]
        [Display(Name = "Student Last Name")]
        public string StudentLastName { get; set; }

        [Required()]
        [Display(Name = "Address")]
        public string StudentAddress { get; set; }

        [Required()]
        [Display(Name = "City")]
        public string StudentCity { get; set; }

        [Required()]
        [Display(Name = "State")]
        public string StudentState { get; set; }

        [Required()]
        [Display(Name = "Zip Code")]
        public Nullable<int> StudentZipCode { get; set; }

        [Required()]
        [Display(Name = "Phone")]
        public string StudentPhone { get; set; }

        [Required()]
        [Display(Name = "Performance Medium")]
        public string PerformanceMedium { get; set; }

        [Required()]
        [Display(Name = "High School Graduation Year")]
        public Nullable<int> GraduationYear { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudentContact> StudentContacts { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InterestAreatoStudent> InterestAreatoStudents { get; set; }
    }
}
