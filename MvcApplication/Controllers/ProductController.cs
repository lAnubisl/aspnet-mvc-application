using System.Web.Mvc;
using MvcApplication.Controllers.Base;
using PresentationService.Interfaces;

namespace MvcApplication.Controllers
{
    public class ProductController : CheckModelIsNullController
    {
        private readonly IProductPresentationService productPresentationService;

        public ProductController(IProductPresentationService productPresentationService)
        {
            this.productPresentationService = productPresentationService;
        }

        public ActionResult View(long id)
        {
            return View(productPresentationService.LoadViewProductModel(id));
        }
    }
}