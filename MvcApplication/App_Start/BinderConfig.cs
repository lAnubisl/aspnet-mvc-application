using System.Web.Mvc;
using MvcApplication.Binders.Admin.Category;
using MvcApplication.Binders.Admin.Consignment;
using MvcApplication.Binders.Admin.Product;
using PresentationService;
using PresentationService.Interfaces.Admin;
using PresentationService.Models.AdminModels.CategoryModels;
using PresentationService.Models.AdminModels.ConsignmentModels;
using PresentationService.Models.AdminModels.ProductModels;

namespace MvcApplication.App_Start
{
    public class BinderConfig
    {
        public static void RegisterBinders()
        {
            ModelBinders.Binders.Add(typeof(CategoryEditModel), new CategoryEditModelBinder(IOC.Resolve<ICategoryPresentationService>()));
            ModelBinders.Binders.Add(typeof(ProductEditModel), new ProductEditModelBinder(IOC.Resolve<IProductPresentationService>()));
            ModelBinders.Binders.Add(typeof(ConsignmentEditModel), new ConsignmentEditModelBinder(IOC.Resolve<IConsignmentPresentationService>()));
        }
    }
}