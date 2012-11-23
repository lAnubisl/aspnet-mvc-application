using System;
using System.Collections.Specialized;
using System.Web.Mvc;
using MvcApplication.Controllers.Base;
using PresentationService.Interfaces;

namespace MvcApplication.Controllers
{
    public class HomeController : CheckModelIsNullController
    {
        private readonly IHomePresentationService homePresentationService;

        public HomeController(IHomePresentationService homePresentationService)
        {
            this.homePresentationService = homePresentationService;
        }

        public ActionResult LogOn()
        {
            return RedirectToAction("Authentication", "user");
        }

        public ActionResult Index()
        {
            return View(homePresentationService.LoadHomeIndexModel());
        }

        public ActionResult Test()
        {
            return View();
            string cookies;
            var response = Anubis.Utils.WebRequestHelper.DownloadString(
                                                         new Uri("https://accounts.google.com/o/oauth2/token"),
                                                         new NameValueCollection()
                                                             {
                                                                 { "code", "4/3WS6X958-bX9TZMpXOC0yVvY43Tg.EjsgG1N66WkdsNf4jSVKMpZwqfs5dgI" },
                                                                 { "client_id", "246889657486.apps.googleusercontent.com" },
                                                                 { "client_secret", "tfbc4e4X7nlg0b1Hk0c_wMpq" },
                                                                 { "grant_type", "authorization_code" },
                                                                 { "redirect_uri", "http://localhost:8413" }
                                                             }, 
                                                             out cookies);

            return new ContentResult { Content = response };
        }
    }
}