using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace USA_Music_Department.Models.Forms.Interest_Form
{
    public class StudentToAdd
    {       
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

        [Required()]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }
        [Display(Name = "Interest Areas")]
        public InterestAreas InterestAreas { get; set; }
    }
}