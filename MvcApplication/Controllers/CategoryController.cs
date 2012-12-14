using System.Web.Mvc;
using MvcApplication.Controllers.Base;
using PresentationService.Interfaces;

namespace MvcApplication.Controllers
{
    public class CategoryController : CheckModelIsNullController
    {
        private readonly ICategoryPresentationService categoryPresentationService;

        public CategoryController(ICategoryPresentationService categoryPresentationService)
        {
            this.categoryPresentationService = categoryPresentationService;
        }

        public ActionResult Index(string seoURL)
        {
            return View(categoryPresentationService.LoadCategoryViewModel(seoURL));
        }

        public ActionResult Menu()
        {
            return View(categoryPresentationService.LoadCategoryMenuModel());
        }
    }
}