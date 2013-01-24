using System;
using System.Globalization;
using System.Web.Mvc;
using PresentationService.Interfaces.Admin;

namespace MvcApplication.Binders.Admin.Consignment
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
            if (controllerContext == null)
            {
                throw new ArgumentNullException("controllerContext");
            }

            var obj = controllerContext.RouteData.Values["id"];
            var id = obj != null ? Convert.ToInt64(obj, CultureInfo.InvariantCulture) : default(long);
            return consignmentPresentationService.LoadConsignmentEditModel(id);
        }
    }
}