using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Web;
using USA_Music_Department.Models.db;

namespace USA_Music_Department.Models.Services
{
    public class StudentService
    {
        private BandStudentDBEntities db = new BandStudentDBEntities();
        public List<Student> Search(string filterType, string searchString, string fromDate, string toDate)
        {
            List<Student> filteredContent;
            if (filterType == "ContactedDate")
            {
                var d_fromDate = Convert.ToDateTime(fromDate);
                var d_toDate = Convert.ToDateTime(toDate);
                filteredContent = (from students in db.Students 
                                  join contact in db.StudentContacts  on students.StudentID  equals contact.StudentId
                                   where contact.ContactedDate > d_fromDate && contact.ContactedDate < d_toDate
                                   select students).ToList();
                return filteredContent;
            }
            else
            {

                filteredContent = db.Students
                                          .Where(filterType + ".Contains(@0)", searchString)
                                          .Select(s => s).ToList();
                return filteredContent;
            }
        }
    }
}