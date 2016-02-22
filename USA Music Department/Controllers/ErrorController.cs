using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace USA_Music_Department.Controllers
{ 
    public class ErrorController : Controller

    {
        [AllowAnonymous]
        public ViewResult Index()
        {
            return View("Error");
        }
        [AllowAnonymous]
        public ViewResult NotFound()
        {
            Response.StatusCode = 404;
            return View("NotFound");
        }
    }

}