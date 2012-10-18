using System.Web.Mvc;
using MVCApplication.Controllers.Base;
using PresentationService.Interfaces;

namespace MVCApplication.Controllers
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