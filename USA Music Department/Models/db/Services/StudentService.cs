using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Web;
using System.Web.Mvc;

namespace USA_Music_Department.Models.db.Services
{
    public class StudentService
    {
        public List<SelectListItem> GetFilterList()
        {
            var columnNames = StudentManipulation.GetColumns("Students");
            var list = columnNames
            .Where(s => !s.Contains("ID"))
            .Select(s => new SelectListItem()
            {
                Text = s.ToString(),
                Value = s
            }).ToList();
            list.Add(new SelectListItem()
            {
                Text = "ContactedDate",
                Value = "ContactedDate"
            });
            return list;
        }
        public void GetStudents(string FilterType, string SearchString, string startDate, string endDate, ref List<Student> filterContent)
        {
            BandStudentDBEntities db = new BandStudentDBEntities();
            if (FilterType != null && FilterType != string.Empty && SearchString != null)
            {
                if (FilterType == "ContactedDate")
                {
                    var dsd = Convert.ToDateTime("2010-04-01");
                    var ded = Convert.ToDateTime("2010-04-01");
                    var x = db.Students
                                        .Join(db.StudentContacts,
                                              sid => sid.StudentID,
                                              cid => cid.StudentId,
                                              (astudent, contact) => new {
                                                  astudent,
                                                  contact.ContactedDate
                                              })
                                        .Where(s => s.ContactedDate >= dsd && s.ContactedDate <= ded)
                                        .Select(s => s);
                    StudentListConvert(x,ref filterContent);
                }
                else
                {
                    filterContent = db.Students
                                      .Where(FilterType + ".Contains(@0)", SearchString)
                                      .Select(s => s).ToList();
                }
            }
        }
        private void StudentListConvert(IEnumerable<dynamic> datesList, ref List<Student> studentList)
        {
            studentList.Clear();
            foreach (dynamic item in datesList)
            {
                Student aStudent = new Student();
                aStudent.StudentID = item.StudentID;
                aStudent.StudentFirstName = item.StudentFirstName;
                aStudent.StudentLastName = item.StudentLastName;
                aStudent.StudentAddress = item.StudentAddress;
                aStudent.StudentCity = item.StudentCity;
                aStudent.StudentState = item.StudentState;
                aStudent.StudentZipCode = item.StudentZipCode;
                aStudent.StudentPhone = item.StudentPhone;
                aStudent.PerformanceMedium = item.PerformanceMedium;
                aStudent.GraduationYear = item.GraduationYear;
                aStudent.EmailAddress = item.EmailAddress;
                studentList.Add(aStudent);
            }
        }
    }
}