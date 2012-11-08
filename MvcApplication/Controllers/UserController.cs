using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DomainService.Enumerations;
using MVCApplication.Controllers.Base;
using PresentationService.Interfaces;
using PresentationService.Models.UserModels;

namespace MVCApplication.Controllers
{
    public class UserController : CheckModelIsNullController
    {
        private const string ReturnUrlToken = "ReturnUrl";
        private readonly IUserPresentationService userPresentationService;

        public UserController(IUserPresentationService userPresentationService)
        {
            this.userPresentationService = userPresentationService;
        }

        [HttpGet]
        public ActionResult Authentication()
        {
            if (!string.IsNullOrEmpty(Request[ReturnUrlToken]))
            {
                Response.Cookies.Add(new HttpCookie(ReturnUrlToken, Request[ReturnUrlToken]));
            }

            return View();
        }

        [HttpGet]
        public ActionResult LogOn()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        public ActionResult ServiceLogOn(LogOnService service, string accessToken)
        {
            var cookieModel = userPresentationService.LoadCookieModel(service, accessToken);

            if (cookieModel != null)
            {
                RegisterAuthCookie(cookieModel.FullName, cookieModel.Email, cookieModel.Role);

                if (Request.Cookies[ReturnUrlToken] != null)
                {
                    var returnUrl = Request.Cookies[ReturnUrlToken].Value;
                    Request.Cookies.Remove(ReturnUrlToken);
                    return Redirect(returnUrl);
                }

                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Authentication");
        }

        [HttpPost]
        public ActionResult LogOn(LogOnUserModel model)
        {
            if (ModelState.IsValid)
            {
                var cookieModel = userPresentationService.LoadCookieModel(model.Email);
                if (cookieModel != null)
                {
                    RegisterAuthCookie(cookieModel.FullName, cookieModel.Email, cookieModel.Role);
                }

                if (Request.Cookies[ReturnUrlToken] != null)
                {
                    var returnUrl = Request.Cookies[ReturnUrlToken].Value;
                    Request.Cookies.Remove(ReturnUrlToken);
                    return Redirect(returnUrl);
                }

                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Register(RegisterUserModel model)
        {
            if (ModelState.IsValid)
            {
                if (userPresentationService.RegisterNewUser(model))
                {
                    RegisterAuthCookie(model.Email, model.Email, Role.User);
                    return RedirectToAction("Index", "Home");
                }
            }

            return View(model);
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        private void RegisterAuthCookie(string name, string email, Role role)
        {
            var roles = role.ToString("G");
            var ticket = new FormsAuthenticationTicket(
                1,
                name + "/" + email,
                DateTime.Now,
                DateTime.Now.AddYears(20),
                true,
                roles,
                FormsAuthentication.FormsCookiePath);

            var hashCookies = FormsAuthentication.Encrypt(ticket);
            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, hashCookies)
                { Expires = DateTime.Now.AddYears(20) };

            Response.Cookies.Add(cookie);
        }
    }
}
