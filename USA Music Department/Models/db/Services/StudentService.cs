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
            list.Add(new SelectListItem()
            {
                Text = "InterestArea",
                Value = "InterestArea"
            });
            return list;
        }
        public void GetStudents(string FilterType, string SearchString, string startDate, string endDate, ref List<Student> filterContent)
        {
            BandStudentDBEntities db = new BandStudentDBEntities();
            if (FilterType != null || FilterType != string.Empty || SearchString != null)
            {
                if (FilterType == "ContactedDate")
                {
                    if (!(startDate == string.Empty) && !(endDate == string.Empty))
                    {
                        var dsd = Convert.ToDateTime(startDate);
                        var ded = Convert.ToDateTime(endDate).AddDays(1);
                        var x = (from a in db.Students
                                 join a2 in db.StudentContacts on a.StudentID equals a2.StudentId
                                 where a2.ContactedDate >= dsd && a2.ContactedDate < ded
                                 select a).ToList();

                        filterContent = x.GroupBy(p => p.StudentID).Select(g => g.FirstOrDefault()).ToList();
                        //    db.Students
                        //                    .Join(db.StudentContacts,
                        //                          sid => sid.StudentID,
                        //                          cid => cid.StudentId,
                        //                          (astudent, contact) => new
                        //                          {
                        //                              astudent,
                        //                              contact.ContactedDate
                        //                          })
                        //                    .Where(s => s.ContactedDate >= dsd && s.ContactedDate <= ded)
                        //                    .Select(s => s);
                        //StudentListConvert(x, ref filterContent);
                    }
                }
                if (FilterType == "InterestArea")
                {
                    var x = (from a in db.Students
                             join a2 in db.InterestAreatoStudents on a.StudentID equals a2.StudentID
                             join a3 in db.InterestAreas on a2.InterestAreaID equals a3.InterestAreaID
                             where a3.InterestAreaName.Contains(SearchString)
                             select a).ToList();
                    filterContent = x.GroupBy(p => p.StudentID).Select(g => g.FirstOrDefault()).ToList();
                }
                if (FilterType == "ApplicationDate")
                {
                    var dsd = Convert.ToDateTime(startDate);
                    var ded = Convert.ToDateTime(endDate).AddDays(1);
                    filterContent = (from a in db.Students
                             where a.ApplicationDate >= dsd && a.ApplicationDate < ded
                    select a).ToList();
                }
                else
                {
                    try
                    {
                        filterContent = db.Students
                                      .Where(FilterType + ".Contains(@0)", SearchString)
                                      .Select(s => s).ToList();
                    }
                    catch (Exception)
                    {

                       
                    }
                    
                }
            }
        }
        public List<StudentExport> exportList(List<Student> list)
        {          
            BandStudentDBEntities db = new BandStudentDBEntities();
            var export = (from student in list                         
                          select new StudentExport
                          {
                              StudentFirstName =  student.StudentFirstName,
                              StudentLastName = student.StudentLastName,
                              StudentAddress = student.StudentAddress,
                              StudentCity = student.StudentCity,
                              StudentState =  student.StudentState,
                              StudentZipCode = student.StudentZipCode,
                              StudentPhone = student.StudentPhone,
                              PerformanceMedium = student.PerformanceMedium,
                              GraduationYear = student.GraduationYear,
                              EmailAddress = student.EmailAddress,
                              ApplicationDate = student.ApplicationDateSubString
                          }).ToList();
            return export;
        }
        //private void StudentListConvert(IEnumerable<dynamic> datesList, ref List<Student> studentList)
        //{
        //    if (!(studentList == null))
        //    {
        //        studentList.Clear();
        //    }
        //    Student aStudent = new Student();
        //    foreach (dynamic item in datesList)
        //        {
        //            aStudent.StudentID = item.StudentID;
        //            aStudent.StudentFirstName = item.StudentFirstName;
        //            aStudent.StudentLastName = item.StudentLastName;
        //            aStudent.StudentAddress = item.StudentAddress;
        //            aStudent.StudentCity = item.StudentCity;
        //            aStudent.StudentState = item.StudentState;
        //            aStudent.StudentZipCode = item.StudentZipCode;
        //            aStudent.StudentPhone = item.StudentPhone;
        //            aStudent.PerformanceMedium = item.PerformanceMedium;
        //            aStudent.GraduationYear = item.GraduationYear;
        //            aStudent.EmailAddress = item.EmailAddress;
        //            studentList.Add(aStudent);
        //        }            
        //}
    }
}