namespace KhorshidBare.Controllers
{
    using System.Security.Claims;
    using System.Web;
    using System.Web.Mvc;
    using KhorshidBare.Models;

    [AllowAnonymous]
    public class AuthController : Controller
    {
        // GET: Auth
        public ActionResult Login(string returnUrl)
        {
            var login = new KhorshidLogin
            {
                ReturnUrl = returnUrl
            };
            return this.View(login);
        }

        [HttpPost]
        public ActionResult Login(KhorshidLogin login)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }
            //Test
            if (login.Email == "test@test.com" && login.Password == "asd")
            {
                var identity = new ClaimsIdentity(new[]
                                                    {
                                                        new Claim(ClaimTypes.Name, "Behrang"), 
                                                        new Claim(ClaimTypes.Email,"BehrangBina@hotmail.com"), 
                                                        new Claim(ClaimTypes.Country,"Iran")                                             
                                                    }, "ApplicationCookie");
                
                var ctx = this.Request.GetOwinContext();
                var authManager = ctx.Authentication;
                login.ReturnUrl=("Image/Index");
                authManager.SignIn(identity);
                return View("../Image/Index");
            }
            // user authN failed
            this.ModelState.AddModelError("", "Invalid email or password");
            return this.View();
        }
        private string GetRedirectUrl(string returnUrl)
        {
            if (string.IsNullOrEmpty(returnUrl) || !this.Url.IsLocalUrl(returnUrl))
            {
                return this.Url.Action("Index", "home");
            }

            return returnUrl;
        }
        public ActionResult LogOut()
        {
            var ctx = Request.GetOwinContext();
            var authManager = ctx.Authentication;
            authManager.SignOut("ApplicationCookie");
            return RedirectToAction("index", "home");
        }
    }
}