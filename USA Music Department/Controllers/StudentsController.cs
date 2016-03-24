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

namespace USA_Music_Department.Controllers
{
    public class StudentsController : Controller
    {
        private BandStudentDBEntities db = new BandStudentDBEntities();
        private List<Student> filteredContent;

        [Authorize(Roles="CanView")]
        // GET: Students
        [Authorize(Roles = "CanView")]
        public ActionResult Index(string FilterType, string SearchString)
        {
            var columnNames = StudentManipulation.GetColumns("Students");
            Session["filterType"] = columnNames
                .Where(s =>!s.Contains("ID"))
                .Select(s => new SelectListItem()
            {
                Text = s.ToString(),
                Value = s
            }).ToList();
            if (FilterType != null && FilterType != string.Empty && SearchString != null && SearchString != string.Empty)
            {
                filteredContent = db.Students
                                      .Where(FilterType + ".Contains(@0)", SearchString)
                                      .Select(s => s).ToList();
                return View(filteredContent);
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
            Student student = db.Students.Find(id);
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
        public ActionResult Edit([Bind(Include = "StudentID,StudentFirstName,StudentLastName,StudentAddress,StudentCity,StudentState,StudentZipCode,StudentPhone,PerformanceMedium,GraduationYear")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
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
            else
            {
                db.DeleteStudentData(id);
            }
            return RedirectToAction("Index");
        }

        // POST: Students/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Student student = db.Students.Find(id);
        //    db.Students.Remove(student);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

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

            if (exportDeffinition == "all")
            {
                db.Students.ToCsv(Server.MapPath("~/CSV/Student List.csv"));

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

                    filteredContent.ToCsv(Server.MapPath("~/CSV/Fitlered Student List.csv"));

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
