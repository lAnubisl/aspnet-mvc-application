using System.Web;
using System.Web.Mvc;

namespace MvcApplication.Controllers.Base
{
    [ValidateInput(false)]
    public abstract class CheckModelIsNullController : Controller
    {
        protected internal new JsonResult Json(object model, JsonRequestBehavior behavior)
        {
            if (model == null)
            {
                throw new HttpException(404, "not found");
            }

            return base.Json(model, behavior);
        }

        protected internal new ViewResult View(object model)
        {
            if (model == null)
            {
                throw new HttpException(404, "not found");
            }

            return base.View(model);
        }

        protected internal new ViewResult View(string viewName, object model)
        {
            if (model == null)
            {
                throw new HttpException(404, "not found");
            }

            return base.View(viewName, model);
        }
    }
}