using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MarketPlace.Models;
using System.Data.Entity;
using System.Web.Security;
using System.Security.Cryptography;
using System.Text;
using System.IO;

namespace MarketPlace.Controllers
{
    public class AccountController : Controller
    {
        const int WorkFactor = 14;
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                User user = null;

                using (TradePlaceContext db = new TradePlaceContext())
                {
                    user = db.Users.FirstOrDefault(u => u.Email == model.Login);
                    if (BCrypt.Net.BCrypt.Verify(model.Password, user.Password))
                    {
                        FormsAuthentication.SetAuthCookie(model.Login, true);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "User with this login and password don`t exist");
                    }
                }
            }

            return View(model);
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                User user = null;
                using (TradePlaceContext db = new TradePlaceContext())
                {
                    user = db.Users.FirstOrDefault(u => u.Email == model.Login);
                }
                if (user == null)
                {
                    using (TradePlaceContext db = new TradePlaceContext())
                    {
                        var hashedPassword = BCrypt.Net.BCrypt.HashPassword(model.Password, WorkFactor);
                        db.Users.Add(new User { Email = model.Login, Password = hashedPassword, Age = model.Age });
                        db.SaveChanges();

                        user = db.Users.Where(u => u.Email == model.Login && u.Password == model.Password).FirstOrDefault();
                    }
                    if (user != null)
                    {
                        FormsAuthentication.SetAuthCookie(model.Login, true);
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "User with this Login already exist");
                }
            }

            return View(model);
        }
        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}
