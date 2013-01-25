using System;
using System.Web.Mvc;
using System.Web.Routing;
using PresentationService;

namespace MvcApplication.Common
{
    public class ControllerFactory : DefaultControllerFactory
    {
        public override void ReleaseController(IController controller)
        {
            var disposable = controller as IDisposable;
            if (disposable != null)
            {
                disposable.Dispose();
            }

            IOC.Release(controller);
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return (IController)IOC.Resolve(controllerType);
        }
    }
}