using System.Collections.Generic;
using System.Web.Mvc;
using MvcApplication.Models;
using SelectListItem = MvcApplication.Models.SelectListItem;

namespace MvcApplication.Controllers
{
    public class SandboxController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View(new SandboxModel());
        }

        [HttpPost]
        public ActionResult Index(SandboxModel model)
        {
            return View(new SandboxModel());
        }

        [HttpPost]
        public JsonResult LoadVersionNames(long pubCodeId)
        {
            var result = new List<SelectListItem>();
            if (pubCodeId < 100)
            {
                result.Add(new SelectListItem { Value = 1, Text = "Alpha" });
                result.Add(new SelectListItem { Value = 2, Text = "Beta" });
                result.Add(new SelectListItem { Value = 3, Text = "Gamma" });
                result.Add(new SelectListItem { Value = 4, Text = "Delta" });
            }

            return new JsonResult { Data = result };
        }
    }
}
