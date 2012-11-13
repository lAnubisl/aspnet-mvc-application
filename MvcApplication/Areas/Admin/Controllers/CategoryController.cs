using System.Web.Mvc;
using MVCApplication.Controllers.Base;
using PresentationService.Interfaces.Admin;
using PresentationService.Models.AdminModels.CategoryModels;

namespace MVCApplication.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CategoryController : CheckModelIsNullController
    {
        private readonly ICategoryPresentationService categoryPresentationService;

        public CategoryController(ICategoryPresentationService categoryPresentationService)
        {
            this.categoryPresentationService = categoryPresentationService;
        }

        public ActionResult Index()
        {
            return View(categoryPresentationService.LoadCategoryIndexModel());
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
            return View("Edit", categoryPresentationService.LoadCategoryEditModel(id));
        }

        [HttpPost]
        public ActionResult Edit(CategoryEditModel model)
        {
            if (ModelState.IsValid)
            {
                categoryPresentationService.SaveCategoryEditModel(model);
                return RedirectToAction("Index");
            }

            return View("Edit", model);
        }
    }
}