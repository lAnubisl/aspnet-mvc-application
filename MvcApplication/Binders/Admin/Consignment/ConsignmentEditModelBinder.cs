using System;
using System.Web.Mvc;
using PresentationService.Interfaces.Admin;

namespace MVCApplication.Binders.Admin.Consignment
{
    public class ConsignmentEditModelBinder : DefaultModelBinder
    {
        private readonly IConsignmentPresentationService consignmentPresentationService;

        public ConsignmentEditModelBinder(IConsignmentPresentationService consignmentPresentationService)
        {
            this.consignmentPresentationService = consignmentPresentationService;
        }

        protected override object CreateModel(ControllerContext controllerContext, ModelBindingContext bindingContext, Type modelType)
        {
            var obj = controllerContext.RouteData.Values["id"];
            var id = obj != null ? Convert.ToInt64(obj) : default(long);
            return consignmentPresentationService.LoadConsignmentEditModel(id);
        }
    }
}