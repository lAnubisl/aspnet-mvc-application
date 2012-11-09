using System.Web.Mvc;
using MVCApplication.Controllers.Base;
using PresentationService.Interfaces.Admin;
using PresentationService.Models.AdminModels.ProductModels;

namespace MVCApplication.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProductController : CheckModelIsNullController
    {
        private readonly IProductPresentationService productPresentationService;

        public ProductController(IProductPresentationService productPresentationService)
        {
            this.productPresentationService = productPresentationService;
        }

        public ActionResult Index()
        {
            return View(productPresentationService.LoadProductIndexModel());
        }

        [HttpGet]
        public ActionResult Add()
        {
            return Edit(default(long));
        }

        [HttpPost]
        public ActionResult Add(ProductEditModel model)
        {
            return Edit(model);
        }

        [HttpGet]
        public ActionResult Edit(long id)
        {
            return View("Edit", productPresentationService.LoadProductEditModel(id));
        }

        [HttpPost]
        public ActionResult Edit(ProductEditModel model)
        {
            if (ModelState.IsValid)
            {
                productPresentationService.SaveProductEditModel(model);
                return RedirectToAction("Index");
            }

            return View("Edit", model);
        }

        public ActionResult UploadImage()
        {
            return View("UploadImage", new ProductUploadImageModel());
        }

        [HttpPost]
        public ActionResult UploadImage(ProductUploadImageModel model)
        {
            if (ModelState.IsValid)
            {
                
            }

            return View("UploadImage", model);
        }
    }
}