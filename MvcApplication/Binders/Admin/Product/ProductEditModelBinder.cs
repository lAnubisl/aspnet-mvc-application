using System;
using System.Web.Mvc;
using PresentationService.Interfaces.Admin;

namespace MVCApplication.Binders.Admin.Product
{
    public class ProductEditModelBinder : DefaultModelBinder
    {
        private readonly IProductPresentationService productPresentationService;

        public ProductEditModelBinder(IProductPresentationService productPresentationService)
        {
            this.productPresentationService = productPresentationService;
        }

        protected override object CreateModel(
            ControllerContext controllerContext, ModelBindingContext bindingContext, Type modelType)
        {
            var obj = controllerContext.RouteData.Values["id"];
            var id = obj != null ? Convert.ToInt64(obj) : default(long);
            var model = productPresentationService.LoadProductEditModel(id);
            model.CreatedBy = MvcApplication.LoggedInUser;
            return model;
        }
    }
}