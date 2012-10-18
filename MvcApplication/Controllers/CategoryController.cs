using System.Web.Mvc;
using MVCApplication.Controllers.Base;
using PresentationService.Interfaces;

namespace MVCApplication.Controllers
{
    public class CategoryController : CheckModelIsNullController
    {
        private readonly ICategoryPresentationService categoryPresentationService;

        public CategoryController(ICategoryPresentationService categoryPresentationService)
        {
            this.categoryPresentationService = categoryPresentationService;
        }

        public ActionResult View(long id)
        {
            return View(categoryPresentationService.LoadCategoryViewModel(id));
        }

        public ActionResult Menu()
        {
            return View(categoryPresentationService.LoadCategoryMenuModel());
        }
    }
}