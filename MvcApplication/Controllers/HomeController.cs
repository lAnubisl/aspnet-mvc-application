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

        [OutputCache(Duration = 10)]
        public ActionResult Index()
        {
            return View(homePresentationService.LoadHomeIndexModel());
        }
    }
}