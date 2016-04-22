using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using USA_Music_Department.Models;
using USA_Music_Department.Models.db;
using USA_Music_Department.Models.Users;
using Microsoft.AspNet.Identity.EntityFramework;

namespace USA_Music_Department.Controllers
{
    public class UsersController : Controller
    {
        private BandStudentDBEntities db = new BandStudentDBEntities();
        [Authorize(Roles ="Admin")]
        // GET: Users
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View(db.C_vGetUsers.ToList());
        }

        // GET: Users/Details/5
        [Authorize(Roles = "Admin")]
        public ActionResult Details(string id, string name)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            C_vGetUsers c_vGetUsers = db.C_vGetUsers.Find(id);
            UserInformation user = UserManipulation.Details(id);
            user.Username = name;
            if (c_vGetUsers == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create([Bind(Include = "id,username,UserFirstName,UserLastName")] C_vGetUsers c_vGetUsers)
        {
            if (ModelState.IsValid)
            {
                db.C_vGetUsers.Add(c_vGetUsers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(c_vGetUsers);
        }

        // GET: Users/EditUserInfo/5
        [Authorize(Roles = "Admin")]
        public ActionResult EditUserInfo(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            C_vGetUsers c_vGetUsers = db.C_vGetUsers.Find(id);

            var user = new Models.db.User();

            user = UserManipulation.GetUserInfo(c_vGetUsers.username);
            user.UserName = c_vGetUsers.username;
            var userid = user.UserName;
            
            if (c_vGetUsers == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/EditUserInfo/5
        [Authorize(Roles = "Admin")]
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditUserInfo(User user)
        {
            var db = new BandStudentDBEntities();
            if (ModelState.IsValid)
            {
                db.UpdateUserRecord(user.UserID, user.UserName, user.UserFirstName, user.UserLastName, user.Active);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }


        // GET: Users/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(string id, string name)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            C_vGetUsers c_vGetUsers = db.C_vGetUsers.Find(id);
            UserInformation user = UserManipulation.Details(id);
            user.Userid = id;
            user.Username = name;
            if (c_vGetUsers == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }
        // POST: Users/Edit/5
        [Authorize(Roles = "Admin")]
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserInformation user)
        {
            if (ModelState.IsValid)
            {
                //UserManipulation.UpdateRoles(user.Userid, user.RoleCanView, user.RoleCanEdit, user.RoleAdmin);
                var AppUser = new ApplicationUser() { Id = user.Userid };

                var userroles = new UserInformation();
                userroles = UserManipulation.UpdateRoles(user.Userid, user.RoleCanView, user.RoleCanEdit, user.RoleAdmin);

                if (userroles.RoleAdmin == true)
                {
                    UserManager.AddToRole(AppUser.Id, "Admin");
                }
                if(userroles.RoleCanEdit == true)
                {
                    UserManager.AddToRole(AppUser.Id, "CanEdit");
                }
                if (userroles.RoleCanView == true)
                {
                    UserManager.AddToRole(AppUser.Id, "CanView");
                }
                if (userroles.RoleAdmin == false)
                {
                    UserManager.RemoveFromRole(AppUser.Id, "Admin");
                }
                if (userroles.RoleCanEdit == false)
                {
                    UserManager.RemoveFromRole(AppUser.Id, "CanEdit");
                }
                if (userroles.RoleCanView == false)
                {
                    UserManager.RemoveFromRole(AppUser.Id, "CanView");
                }
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        // GET: Users/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(string id, string username, string userfirstname, string userlastname)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            C_vGetUsers user = new C_vGetUsers();
            user.id = id;
            user.username = username;
            user.UserFirstName = userfirstname;
            user.UserLastName = userlastname;
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(C_vGetUsers user)
        {
            ApplicationUser appuser = new ApplicationUser();
            appuser = UserManager.FindByEmail(user.username);
            db.DeleteUser(user.username);
            UserManager.Delete(appuser);
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
        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
    }
}
