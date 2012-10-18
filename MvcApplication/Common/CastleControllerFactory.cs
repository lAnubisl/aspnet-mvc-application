using System;
using System.Web.Mvc;
using System.Web.Routing;
using PresentationService;

namespace MVCApplication.Common
{
    public class CastleControllerFactory : DefaultControllerFactory
    {
        public override void ReleaseController(IController controller)
        {
            var disposable = controller as IDisposable;
            if (disposable != null)
            {
                disposable.Dispose();
            }

            IOC.ContainerInstance.Release(controller);
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return (IController)IOC.ContainerInstance.Resolve(controllerType);
        }
    }
}