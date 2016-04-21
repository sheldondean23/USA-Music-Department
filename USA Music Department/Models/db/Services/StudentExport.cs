using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace USA_Music_Department.Models.db.Services
{
    public class StudentExport
    {
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
        public string ApplicationDate { get; set; }
    }
}