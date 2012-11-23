using System;
using System.Web.Mvc;
using MvcApplication.Controllers.Base;
using PresentationService.Interfaces.Admin;
using PresentationService.Models.AdminModels.ProductModels;
using PresentationService.Properties;

namespace MvcApplication.Areas.Admin.Controllers
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

        public ActionResult Add()
        {
            return Edit(default(long));
        }

        [HttpPost]
        public ActionResult Add(ProductEditModel model)
        {
            return Edit(model);
        }

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
            if (model != null && ModelState.IsValid)
            {
                var url = model.ImageUrl;

                if (url == null)
                {
                    url = new Uri(string.Format("{0}/{1}.jpg", Settings.Default.ProductImagesPath, Guid.NewGuid()));
                }

                productPresentationService.SaveProductImage(model.File, url);

                model.SuccessModel(url);
            }

            return View("UploadImage", model);
        }

        [HttpPost]
        public JsonResult DeleteImage(Uri imageUrl)
        {
            productPresentationService.DeleteImage(imageUrl);
            return new JsonResult();
        }
    }
}