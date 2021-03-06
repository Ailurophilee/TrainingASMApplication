﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrainingApplication.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;

namespace TrainingApplication.Controllers
{
    public class AuthenController : Controller
    {

        // GET: Authen
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Account acc)
        {
            if (ModelState.IsValid)
            {
                if (acc.Password.Equals(acc.ConfirmPassword))
                {
                    var userStore = new UserStore<IdentityUser>();
                    var manager = new UserManager<IdentityUser>(userStore);

                    var user = new IdentityUser() { UserName = acc.UserName };
                    IdentityResult result = manager.Create(user, acc.Password);

                    if (!result.Succeeded)
                    {
                        ModelState.AddModelError("", "Error Adding new User " + result.Errors.First());
                        manager.AddToRole(user.Id, acc.UserRoles);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Confirm Password not match");
                }
            }
            return View(acc);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Account acc)
        {
            var userStore = new UserStore<IdentityUser>();
            var manager = new UserManager<IdentityUser>(userStore);

            var user = manager.Find(acc.UserName, acc.Password);

            if (user != null)
            {
                var authenticationManager = HttpContext.GetOwinContext().Authentication;
                var userIdentity = manager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

                authenticationManager.SignIn(new AuthenticationProperties { IsPersistent = false }, userIdentity);
                return RedirectToAction("Index", "Trainers");
            }
            else
            {
                ModelState.AddModelError("", "Invalid username or password. ");
            }
            return View(acc);
        }

        public ActionResult Logout()
        {
            var authenticationManager = HttpContext.GetOwinContext().Authentication;
            authenticationManager.SignOut();
            return RedirectToAction("Login", "Authen");
        }

        public static void CreateAccount(string userName, string password, string role)
        {
            var userStore = new UserStore<IdentityUser>();
            var manager = new UserManager<IdentityUser>(userStore);

            var user = new IdentityUser(userName);
            manager.Create(user, password);

            manager.AddToRole(user.Id, role);
        }
    }
}