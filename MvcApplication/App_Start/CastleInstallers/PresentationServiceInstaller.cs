using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace MvcApplication.App_Start.CastleInstallers
{
    public class PresentationServiceInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            if (container != null)
            {
                container
                .Register(Classes.FromAssemblyNamed("PresentationService")
                              .BasedOn(typeof(PresentationService.Interfaces.IBasePresentationService))
                              .LifestyleSingleton()
                              .WithServiceDefaultInterfaces());
            }
        }
    }
}