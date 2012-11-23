using System.Web.Mvc;
using MvcApplication.Controllers.Base;

namespace MvcApplication.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class HomeController : CheckModelIsNullController
    {
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Category");
        }
    }
}