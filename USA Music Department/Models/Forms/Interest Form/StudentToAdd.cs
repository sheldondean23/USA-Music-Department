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
        [Required(ErrorMessage = "First Name Required*")]
        [Display(Name = "Student First Name*")]
        [RegularExpression("([a-zA-Z ]+)", ErrorMessage = "First Name can only contain letters")]
        public string StudentFirstName { get; set; }

        [Required(ErrorMessage = "Last Name Required*")]
        [Display(Name = "Student Last Name*")]
        [RegularExpression("([a-zA-Z .]+)", ErrorMessage = "Last Name can only contain letters or a period")]
        public string StudentLastName { get; set; }

        [Required(ErrorMessage = "Street Address Required*")]
        [Display(Name = "Address*")]
        [RegularExpression("([a-zA-Z0-9 .]+)", ErrorMessage = "Street Address can only contain letters, numbers, and '.'")]
        public string StudentAddress { get; set; }

        [Required(ErrorMessage = "City Required*")]
        [Display(Name = "City*")]
        [RegularExpression("[a-zA-Z .]+", ErrorMessage = "City Name can only contain letters or '.'")]
        public string StudentCity { get; set; }

        [Required(ErrorMessage = "State Required")]
        [Display(Name = "State*")]
        [RegularExpression("([a-zA-Z ]+)", ErrorMessage = "State can only contain Letters")]
        public string StudentState { get; set; }

        [Required(ErrorMessage = "Zip Code Required")]
        [Display(Name = "Zip Code*")]
        [RegularExpression("[0-9]{5}(?:-[0-9]{4})?", ErrorMessage = "Invalid Zip Ex:99999")] //Cannot add extended zips due to integer
        public Nullable<int> StudentZipCode { get; set; }

        [Required(ErrorMessage = "Phone Number Required")]
        [Display(Name = "Phone*")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression("([0-9]{3})?[-. ]?([0-9]{3})[-. ]?([0-9]{4})", ErrorMessage = "Not a valid Phone number Ex: 123-456-7890 ")] 
        public string StudentPhone { get; set; }

        [Required(ErrorMessage = "Performance Medium Required")]
        [Display(Name = "Performance Medium*")]
        [RegularExpression("([a-zA-Z ]+)", ErrorMessage = "Performance Medium can only contain letters")]
        public string PerformanceMedium { get; set; }

        [Required(ErrorMessage = "Grad Year Required")]
        [Display(Name = "High School Graduation Year *")]
        [RegularExpression("(19|20)[0-9]{2}", ErrorMessage = "Year must be between 1900 - 2099")]
        public Nullable<int> GraduationYear { get; set; }

        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string EmailAddress { get; set; }

        [Display(Name = "Interest Areas*")]
        [Required(ErrorMessage = "Please select at least one interest")]
        public InterestAreas InterestAreas { get; set; }
    }
}