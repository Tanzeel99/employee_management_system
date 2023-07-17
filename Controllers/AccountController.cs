using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AssignMVC.Models;
using System.Web.Security;
using Scrypt;

namespace AssignMVC.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(membership model)
        {
            ScryptEncoder encoder = new ScryptEncoder();
            assignEntities db = new assignEntities();
            var validuser = (from u in db.User
                             where u.UserName.Equals(model.UserName)
                             select u).SingleOrDefault();
            if (validuser == null)
            {
                ModelState.AddModelError("", "Invalid User Name and Password");
                return View();
            }
            if (model.Password == null) {
                ModelState.AddModelError("", "");
            }
            else
            {
                bool isValid = encoder.Compare(model.Password, validuser.Password);
                if (isValid)
                {
                    Session.Add("username", model.UserName);
                    FormsAuthentication.SetAuthCookie(model.UserName, false);
                    return RedirectToAction("List", "Home");
                }
                ModelState.AddModelError("", "Invalid User Name and Password");
            }
            /*bool isValid = db.User.Any(x => x.UserName == model.UserName && x.Password == model.Password);*/
/*            bool isValid = encoder.Compare(model.Password, validuser.Password);
            if (isValid)
            {
                FormsAuthentication.SetAuthCookie(model.UserName, false);
                return RedirectToAction("List", "Home");
            }
            ModelState.AddModelError("", "Invalid User Name and Password");*/
            return View();
        }        
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(User model)
        {
            ScryptEncoder encoder = new ScryptEncoder();
            assignEntities db = new assignEntities();
            var nuser = new User
            {
                UserName = model.UserName,
                Password = encoder.Encode(model.Password)
            };
           
            db.User.Add(nuser);
            db.SaveChanges();
            return RedirectToAction("Login");
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();
            return RedirectToAction("Login");
        }
    }
}