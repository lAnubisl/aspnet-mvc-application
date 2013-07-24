using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace MvcApplication.App_Start.CastleInstallers
{
    public class ControllerInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            if (container != null)
            {
                container.Register(Classes.FromThisAssembly().BasedOn(typeof(IController)).LifestyleTransient());
            }
        }
    }
}