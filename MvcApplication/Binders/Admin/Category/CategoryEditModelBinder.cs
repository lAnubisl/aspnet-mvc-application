using System;
using System.Web.Mvc;
using PresentationService.Interfaces.Admin;

namespace MvcApplication.Binders.Admin.Category
{
    public class CategoryEditModelBinder : DefaultModelBinder
    {
        private readonly ICategoryPresentationService categoryPresentationService;

        public CategoryEditModelBinder(ICategoryPresentationService categoryPresentationService)
        {
            this.categoryPresentationService = categoryPresentationService;
        }

        protected override object CreateModel(ControllerContext controllerContext, ModelBindingContext bindingContext, Type modelType)
        {
            if (controllerContext == null)
            {
                throw new ArgumentNullException("controllerContext");
            }

            var obj = controllerContext.RouteData.Values["id"];
            var id = obj != null ? Convert.ToInt64(obj) : default(long);
            return categoryPresentationService.LoadCategoryEditModel(id);
        }
    }
}