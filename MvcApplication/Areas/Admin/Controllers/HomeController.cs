using System.Web.Mvc;
using MVCApplication.Controllers.Base;

namespace MVCApplication.Areas.Admin.Controllers
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