using CsvFiles;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Net;
using System.Web;
using System.Web.Mvc;
using USA_Music_Department.Models.db;
using USA_Music_Department.Models.Forms.Interest_Form;
using USA_Music_Department.Models.Users;
using USA_Music_Department.Controllers;
using Microsoft.AspNet.Identity;
using USA_Music_Department.Models.db.Services;

namespace USA_Music_Department.Controllers
{
    public class StudentsController : Controller
    {
        private BandStudentDBEntities db = new BandStudentDBEntities();
        private StudentService service = new StudentService();
        private List<Student> filteredContent = new List<Student>();

        // GET: Students
        [Authorize(Roles = "CanView")]
        public ActionResult Index(string FilterType, string SearchString, string StartDate, string EndDate)
        {
           // Session["filteredContent"].clear;
            Session["filterType"] = service.GetFilterList();
            service.GetStudents(FilterType, SearchString, StartDate, EndDate, ref filteredContent);
            if (!(FilterType == null || FilterType == ""))
            {
                if (!(filteredContent == null))
                {
                    Session["filteredContent"] = filteredContent;
                    return View(filteredContent);
                }
            }
            return View(db.Students.ToList());
        }

        // GET: Students
        [Authorize(Roles = "CanView")]
        public ActionResult ContactsList(int? id)
        {

            var model = (from a in db.Students
                         join a2 in db.StudentContacts on a.StudentID equals a2.StudentId
                         join a3 in db.Users on a2.ContactedBy equals a3.UserID
                         let employeename = (a3.UserFirstName + " " + a3.UserLastName).ToString()
                         where a.StudentID == id
                         select new ContactList { EmployeeName = employeename, ContactedDate = a2.ContactedDate.ToString(), ContactMedium = a2.ContactedMedium });
            ViewBag.Id = id;
            return View(model);

        }

        // GET: Students/Details/5
        [Authorize(Roles = "CanView")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentToAdd student = StudentManipulation.Details(id);
            student.StudentID = (int)id;
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Students/Create
        [Authorize(Roles = "CanEdit")]
        public ActionResult Create()
        {
            return RedirectToAction("interest", "Form");
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(StudentToAdd student)
        //{

        //    if (ModelState.IsValid)
        //    {
        //        return RedirectToAction("Index");
        //    }

        //    return View(student);
        //}

        // GET: Students/Edit/5
        [Authorize(Roles = "CanEdit")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentToAdd student = StudentManipulation.Details(id);
            student.StudentID = (int)id;
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Edit/5
        [Authorize(Roles = "CanEdit")]
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(StudentToAdd student)
        {
            if (ModelState.IsValid)
            {
                db.UpdateStudentData(student.StudentID, student.StudentFirstName, student.StudentLastName, student.StudentAddress, student.StudentCity, student.StudentState, student.StudentZipCode, student.StudentPhone, student.PerformanceMedium, student.GraduationYear, student.EmailAddress);
                db.CreateUpdate_InterestAreas(student.StudentID, student.InterestAreas.BM_Music_Education_Vocal, student.InterestAreas.BM_Music_Education_Instrumental, student.InterestAreas.BM_Music_Performance_Vocal,
                                              student.InterestAreas.BM_Music_Performance_Instrumental, student.InterestAreas.BM_Music_Elective_Studies_Business, student.InterestAreas.BM_Music_Elective_Studies_Outside_Fields,
                                              student.InterestAreas.MM_Performance_Piano, student.InterestAreas.MM_Performance_Vocal, student.InterestAreas.MM_Collaborative_Piano, student.InterestAreas.Music_Minor, student.InterestAreas.Instrumental_Ensembles,
                                              student.InterestAreas.Choral_Ensembles, student.InterestAreas.Opera_Theatre, student.InterestAreas.Jaguar_Marching_Band, student.InterestAreas.Other, student.InterestAreas.MM_Concentration_in_Music_Education);
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // GET: Students/Delete/5
        [Authorize(Roles = "CanEdit")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Delete/5
        [Authorize(Roles = "CanEdit")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            db.DeleteStudentData(id);
            return RedirectToAction("Index");
        }

        // GET: Students/Edit/5
        [Authorize(Roles = "CanEdit")]
        public ActionResult StudentContact(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            StudentContact studentcontact = new StudentContact();
            studentcontact.StudentId = id;
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(studentcontact);
        }

        // POST: Students/Edit/5
        [Authorize(Roles = "CanEdit")]
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult StudentContact(StudentContact studentcontact)
        {
            var username = System.Web.HttpContext.Current.User.Identity.GetUserName();
            var user = UserManipulation.GetUserInfo(username);
            if (ModelState.IsValid)
            {
                db.InsertContactRecord(studentcontact.StudentId, user.UserID, studentcontact.ContactedDate, studentcontact.ContactedMedium);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(studentcontact);
        }
                
        [Authorize(Roles = "CanView")]
        public ActionResult Export(string exportDeffinition)
        {
            filteredContent = (List<Student>)Session["filteredContent"];
            if (exportDeffinition == "all")
            {
                var content = db.Students.ToList();
                var export = service.exportList(content);
                export.ToCsv(Server.MapPath("~/CSV/Student List.csv"));

                string filename = "Student List.csv";
                string filepath = Server.MapPath("~/CSV/Student List.csv");
                byte[] filedata = System.IO.File.ReadAllBytes(filepath);
                string contentType = MimeMapping.GetMimeMapping(filepath);
                var cd = new System.Net.Mime.ContentDisposition
                {
                    FileName = filename,
                    Inline = true,
                };

                Response.AppendHeader("Content-Disposition", cd.ToString());

                return File(filedata, contentType);
            }
            else if (exportDeffinition == string.Empty || exportDeffinition == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                if (filteredContent == null)
                {
                    TempData["alertMessage"] = "Error, the filtered list is empty. Please download filtered list, with student data.";
                    return RedirectToAction("Index");
                }
                else
                {
                    var export = service.exportList(filteredContent);
                    export.ToCsv(Server.MapPath("~/CSV/Fitlered Student List.csv"));

                    string filename = "Fitlered Student List.csv";
                    string filepath = Server.MapPath("~/CSV/Fitlered Student List.csv");
                    byte[] filedata = System.IO.File.ReadAllBytes(filepath);
                    string contentType = MimeMapping.GetMimeMapping(filepath);
                    var cd = new System.Net.Mime.ContentDisposition
                    {
                        FileName = filename,
                        Inline = true,
                    };

                    Response.AppendHeader("Content-Disposition", cd.ToString());

                    return File(filedata, contentType);
                }
            }
        }

        [Route("GetSelectedFilter/{id?}"), HttpGet]
        public ActionResult GetSelectedFilter(string id)
        {
            Session["SelectedFilter"] = id;
            return RedirectToAction("Index");
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
