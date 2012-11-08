using System;
using System.Web;
using System.Web.Mvc;
using MVCApplication.Common;
using MVCApplication.Controllers.Base;
using MVCApplication.Controllers.Helpers;
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

        [HttpGet]
        public ActionResult UploadImage()
        {
            return View("UploadImage");
        }

        [HttpPost]
        public ActionResult UploadImage(HttpPostedFileBase qqfile)
        {
            if (qqfile != null)
            {
                if (qqfile.ContentType == "image/jpeg")
                {
                    if (qqfile.ContentLength < 1 * 1024 * 1024)
                    {
                        var fileName = productPresentationService.SaveUploadedImage(qqfile.InputStream);

                        ViewBag.Result = new
                        {
                            filename = fileName,
                            image = Url.Content(ProductImageHelper.ProductTempImage(fileName, ImageSize.Big)),
                            thumb = Url.Content(ProductImageHelper.ProductTempImage(fileName, ImageSize.Small)),
                        };
                    } 
                    else
                    {
                        ModelState.AddModelError("qqFile", "Вы можете загружать только файлы размером не больше 1Мб.");
                    }
            
                } 
                else 
                {
                    ModelState.AddModelError("qqFile", "Вы можете загружать только JPEG файлы.");
                }

            } 
            else 
            {
                ModelState.AddModelError("qqFile", "Вы не загрузили файл.");
            }

            return View("UploadImage");
        }

        [HttpPost]
        public JsonResult DeleteImage(string fileName)
        {
            try
            {
                var result = productPresentationService.DeleteImage(fileName);
                return Json(new { success = result });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, "application/json");
            }
        }
    }
}