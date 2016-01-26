using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace USA_Music_Department.Controllers
{
    public class StudendFormController : Controller
    {
        private BandStudentDBEntities db = new BandStudentDBEntities();
        // GET: StudendForm
        public ActionResult Index()
        {            
            return View(db);
        }

        // GET: StudendForm/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: StudendForm/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudendForm/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: StudendForm/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StudendForm/Edit/5
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

        // GET: StudendForm/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StudendForm/Delete/5
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
