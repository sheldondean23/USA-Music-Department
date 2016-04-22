using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using USA_Music_Department.Models.Forms.Interest_Form;

namespace USA_Music_Department.Controllers
{
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public ActionResult Home()
        {
            return Redirect("http://www.southalabama.edu/colleges/music/");
        }
        [AllowAnonymous]
        public ActionResult Index()
        {           
            return RedirectToAction("interest","Form");
        }
        [AllowAnonymous]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [AllowAnonymous]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}