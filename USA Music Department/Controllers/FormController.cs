using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using USA_Music_Department.Models.Forms.Interest_Form;
using USA_Music_Department.Models.db;

namespace USA_Music_Department.Controllers
{
    public class FormController : Controller
    {
        BandStudentDBEntities db = new BandStudentDBEntities();
        // GET: Form
        public ActionResult Index()
        {
            return View(); 
        }

        // GET: Form/interest
        public ActionResult interest()
        {
            return View();
        }

        // GET: Form/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Form/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Form/AddPerson
        [HttpPost]
        public ActionResult AddPerson([Bind(Include = "StudentID,StudentFirstName,StudentLastName,StudentAddress,StudentCity,StudentState,StudentZipCode,StudentPhone,PerformanceMedium,GraduationYear,EmailAddress")] StudentToAdd student)
        {
            try
            {
                db.InsertStudentData(student.StudentFirstName, student.StudentLastName, student.StudentAddress, student.StudentCity, student.StudentState, student.StudentZipCode, student.StudentPhone, student.PerformanceMedium, student.GraduationYear, student.EmailAddress);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Form/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Form/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Form/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Form/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
