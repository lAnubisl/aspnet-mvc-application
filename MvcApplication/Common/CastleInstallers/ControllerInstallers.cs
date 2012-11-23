using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace MvcApplication.Common.CastleInstallers
{
    public class ControllerInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            if (container != null)
            {
                container.Register(AllTypes.FromThisAssembly().BasedOn(typeof(IController)).LifestyleTransient());
            }
        }
    }
}