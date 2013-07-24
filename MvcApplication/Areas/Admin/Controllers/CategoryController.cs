using System.Web.Mvc;
using MvcApplication.Controllers.Base;
using PresentationService.Interfaces.Admin;
using PresentationService.Models.AdminModels.CategoryModels;

namespace MvcApplication.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CategoryController : CheckModelIsNullController
    {
        private readonly ICategoryPresentationService service;

        public CategoryController(ICategoryPresentationService categoryPresentationService)
        {
            this.service = categoryPresentationService;
        }

        public ActionResult Index()
        {
            return View(service.LoadCategoryIndexModel());
        }

        public ActionResult Add()
        {
            return Edit(default(long));
        }

        [HttpPost]
        public ActionResult Add(CategoryEditModel model)
        {
            return Edit(model);
        }

        public ActionResult Edit(long id)
        {
            return View("Edit", service.LoadCategoryEditModel(id));
        }

        [HttpPost]
        public ActionResult Edit(CategoryEditModel model)
        {
            if (ModelState.IsValid)
            {
                service.SaveCategoryEditModel(model);
                return RedirectToAction("Index");
            }

            return View("Edit", model);
        }

        [HttpPost]
        public RedirectToRouteResult Delete(long id)
        {
            service.DeleteCategory(id);
            return RedirectToAction("Index");
        }
    }
}