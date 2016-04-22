using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using USA_Music_Department.Models.Forms.Interest_Form;
using USA_Music_Department.Models.db;
using System.Net.Http;
using System.Net.Mail;

namespace USA_Music_Department.Controllers
{
    public class FormController : Controller
    {
        
        BandStudentDBEntities db = new BandStudentDBEntities();
        [AllowAnonymous]
        // GET: Form
        public ActionResult Index()
        {
            return View(); 
        }

        // GET: Form/interest
        [AllowAnonymous]
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
        [AllowAnonymous]
        public ActionResult AddPerson(StudentToAdd student)
        {
            try
            {
                StudentManipulation.Insert(student);

                //Email Information
                var myMessage = new SendGrid.SendGridMessage();
                myMessage.AddTo("banddroiddonotreply@gmail.com");
                myMessage.From = new MailAddress("banddroiddonotreply@gmail.com", "USA Music Department");
                myMessage.Subject = "New Student";
                myMessage.Text = student.StudentFirstName + " " + student.StudentLastName + " has submitted an application as of " + DateTime.Now + ".";
                
                transportWeb.DeliverAsync(myMessage);
                //Email Information

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
