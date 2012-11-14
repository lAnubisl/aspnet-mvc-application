using System;
using System.Web.Mvc;
using MVCApplication.Controllers.Base;
using PresentationService.Interfaces;

namespace MVCApplication.Controllers
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

        public ActionResult Config()
        {
            return new FilePathResult(string.Format("{0}web.config", AppDomain.CurrentDomain.BaseDirectory), "text/xml");
        }
    }
}
